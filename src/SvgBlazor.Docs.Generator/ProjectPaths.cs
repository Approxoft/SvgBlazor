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

        private const string ExampleIdentifier = "Example";

        public static string SourcePath { get; set; }

        public static string DocsDirectoryPath => Path.Combine(SourcePath, DocsDirectory);

        public static string DocsAttributesDirectoryPath => Path.Combine(DocsDirectoryPath, DocsPagesDirectory, DocsAttributesDirectory);

        public static string DocsElementsDirectoryPath => Path.Combine(DocsDirectoryPath, DocsPagesDirectory, DocsElementsDirectory);
    }
}
