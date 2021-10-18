using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgBlazor.Docs.Generator
{
    public class ProjectPaths
    {
        private const string DocsDirectory = "SvgBlazor.Docs";

        private const string DocsPagesDirectory = "Pages";

        private const string DocsAttributesDirectory = "Attributes";

        private const string DocsElementsDirectory = "Elements";

        public const string ExampleIdentifier = "Example";

        public static string SourcePath
        {
            get
            {
                var workingPath = Path.GetFullPath(".");
                while (Path.GetFileName(workingPath) != "src" && !string.IsNullOrWhiteSpace(workingPath))
                {
                    workingPath = Path.GetFullPath(Path.Combine(workingPath, @".."));
                }

                return workingPath;
            }
        }

        public static string DocsDirectoryPath
        {
            get
            {
                return Path.Combine(SourcePath, DocsDirectory);
            }
        }

        public static string DocsAttributesDirectoryPath
        {
            get
            {
                return Path.Combine(DocsDirectoryPath, DocsPagesDirectory, DocsAttributesDirectory);
            }
        }

        public static string DocsElementsDirectoryPath
        {
            get
            {
                return Path.Combine(DocsDirectoryPath, DocsPagesDirectory, DocsElementsDirectory);
            }
        }
    }
}
