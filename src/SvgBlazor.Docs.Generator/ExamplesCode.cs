// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SvgBlazor.Docs.Generator
{
    public class ExamplesCode
    {
        public void Generate()
        {
            GenerateItems(ProjectPaths.PagesDirectoryPath);
        }

        public string GetCodeFromFile(string filepath)
        {
            using (StreamReader sr = new (filepath))
            {
                return GetCodeFromStream(sr);
            }
        }

        public string GetCodeFromStream(StreamReader sr)
        {
            var allCode = sr.ReadToEnd();

            MatchCollection matches = Regex.Matches(allCode, @"(#example-code-start.*?\n)([\s\S]*?)(.*?#example-code-end)");

            if (matches.Count == 0)
            {
                return allCode;
            }

            StringBuilder sb = new ();

            for (int i = 0; i < matches.Count; i++)
            {
                if (i > 0)
                {
                    AddCodesSeparator(sb);
                }

                if (matches[i].Groups.Count < 2)
                {
                    break;
                }

                var exampleCode = matches[i].Groups[2].Value;

                sb.Append(CorrectIndentations(exampleCode));
            }

            return sb.ToString();
        }

        private void AddCodesSeparator(StringBuilder sb)
        {
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("...");
            sb.AppendLine();
        }

        private void GenerateItems(string path)
        {
            var directoryInfo = new DirectoryInfo(path);

            foreach (var entry in directoryInfo.GetDirectories())
            {
                GenerateItem(entry);
            }
        }

        private void GenerateItem(DirectoryInfo itemDirectory)
        {
            var files = itemDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories)
                        .Where(s =>
                            (s.Name.EndsWith(".cs") || s.Name.EndsWith(".razor"))
                            && s.DirectoryName.Contains(ProjectPaths.ExampleIdentifier));

            foreach (var itemExample in files)
            {
                string code = GetCodeFromFile(itemExample.FullName);
                var outputPath = itemExample.FullName.Replace(itemExample.Extension, ".html");
                SaveAsHtml(code, outputPath, itemExample.Extension);
            }
        }

        private void SaveAsHtml(string code, string outputPath, string extension)
        {
            var codeClass = extension switch
            {
                ".cs" => "language-csharp",
                ".razor" => "language-cshtml-razor",
                _ => throw new Exception("File extension not supported")
            };

            var encodedCode = HttpUtility.HtmlEncode(code);
            var result = $"<code class=\"{codeClass}\">{encodedCode}</code>";
            File.WriteAllText(outputPath, result);
        }

        private string CorrectIndentations(string code)
        {
            string[] lines = code.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            int indentChars = lines[0].TakeWhile(c => char.IsWhiteSpace(c)).Count();

            if (indentChars == -1)
            {
                return code;
            }

            StringBuilder exampleCode = new ();
            foreach (var line in lines)
            {
                int charsToRemove = Math.Min(indentChars, line.Length);
                exampleCode.AppendLine(line.Remove(0, charsToRemove));
            }

            return exampleCode.ToString().Trim();
        }
    }
}
