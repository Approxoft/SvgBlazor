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
        public const string ExampleIdentifier = "Example";

        private const string DocsDirectory = "SvgBlazor.Docs";

        private const string DocsPagesDirectory = "Pages";

        public static string SourcePath { get; set; }

        public static string DocsDirectoryPath => Path.Combine(SourcePath, DocsDirectory);

        public static string PagesDirectoryPath => Path.Combine(DocsDirectoryPath, DocsPagesDirectory);
    }
}
