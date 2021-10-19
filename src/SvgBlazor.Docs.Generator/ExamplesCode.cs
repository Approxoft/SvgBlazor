using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SvgBlazor.Docs.Generator
{
    public class ExamplesCode
    {
        public void Generate()
        {
            GenerateItems(ProjectPaths.DocsAttributesDirectoryPath);
            GenerateItems(ProjectPaths.DocsElementsDirectoryPath);
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
            var line = SeekToLineContainingText(sr, "void Example");

            StringBuilder exampleCode = new ();
            exampleCode.AppendLine(line);

            int initialIndentLevel = line.Count(c => c == '{');
            ReadCodeBetweenBrackets(initialIndentLevel, sr, exampleCode);

            return CorrectIndentations(exampleCode.ToString());
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
            var itemName = Path.GetFileName(itemDirectory.FullName);
            Console.WriteLine($"Examples for: {itemName}");

            foreach (var itemExample in itemDirectory.GetFiles("*Example.cs", SearchOption.AllDirectories))
            {
                string code = GetCodeFromFile(itemExample.FullName);
                Console.WriteLine(code.ToString());
            }
        }

        private string SeekToLineContainingText(StreamReader sr, string text)
        {
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                if (line.Contains(text))
                {
                    return line;
                }
            }

            return string.Empty;
        }

        private void ReadCodeBetweenBrackets(int initialIndentation, StreamReader sr, StringBuilder code)
        {
            while (sr.Peek() >= 0)
            {
                char c = (char)sr.Read();
                code.Append(c);

                if (c == '{')
                {
                    initialIndentation++;
                }
                else if (c == '}')
                {
                    initialIndentation--;
                    if (initialIndentation == 0)
                    {
                        break;
                    }
                }
            }
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
                if (line.Length >= indentChars)
                {
                    exampleCode.AppendLine(line.Remove(0, indentChars));
                }
            }

            return exampleCode.ToString().Trim();
        }
    }
}
