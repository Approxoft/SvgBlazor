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

            if (itemName=="Text")
            {
                Console.WriteLine("test");
            }

            foreach (var itemExample in itemDirectory.GetFiles("*Example.cs", SearchOption.AllDirectories))
            {
                string code = GetCodeFromFile(itemExample.FullName);
                //Console.WriteLine(code);
                string[] lines = code.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );

                int indentChars = lines[0].TakeWhile(c => char.IsWhiteSpace(c)).Count();

                if (indentChars<0)
                {
                    indentChars = 0;
                }

                StringBuilder exampleCode = new();
                foreach (var line in lines)
                {
                    if (line.Length >= indentChars)
                    {
                        exampleCode.AppendLine(line.Remove(0, indentChars));
                    }
                }

                Console.WriteLine(exampleCode.ToString());
            }
        }

        private string GetCodeFromFile(string filepath)
        {
            StringBuilder exampleCode = new();

            using (StreamReader sr = new(filepath))
            {
                bool exampleCodeStart = false;
                int indentLevel = 0;
                while (sr.Peek() >= 0)
                {
                    if (exampleCodeStart == false)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("void Example"))
                        {
                            exampleCodeStart = true;
                            exampleCode.AppendLine(line);
                        }
                    } else
                    {
                        char c = (char)sr.Read();
                        if (c == '{')
                        {
                            indentLevel++;
                        } else if (c == '}')
                        {
                            if (indentLevel==1 && indentLevel-1 == 0)
                            {
                                exampleCode.Append(c);
                                break;
                            }
                            indentLevel--;
                        }
                        exampleCode.Append(c);
                    }
                }
            }

            return exampleCode.ToString();
        }
    }
}
