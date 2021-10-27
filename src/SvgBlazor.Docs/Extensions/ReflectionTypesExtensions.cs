using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace SvgBlazor.Docs.Extensions
{
    public static class ReflectionTypesExtensions
    {
        private static Dictionary<string, string> loadedXmlDocumentation =
            new Dictionary<string, string>();

        private static HashSet<Assembly> loadedAssemblies = new HashSet<Assembly>();

        public static void LoadXmlDocumentation(Assembly assembly)
        {
            if (loadedAssemblies.Contains(assembly))
            {
                return; // Already loaded
            }

            string xmlFilePath = assembly.GetManifestResourceNames().FirstOrDefault(x => x.Contains($"SvgBlazor.xml"));

            if (File.Exists(xmlFilePath))
            {
                LoadXmlDocumentation(File.ReadAllText(xmlFilePath));
                loadedAssemblies.Add(assembly);
            }
        }

        public static void LoadXmlDocumentation(string xmlDocumentation)
        {
            using XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocumentation));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    loadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
                }
            }
        }

        public static string GetDocumentation(this Type type)
        {
            string key = "T:" + XmlDocumentationKeyHelper(type.FullName, null);
            loadedXmlDocumentation.TryGetValue(key, out string documentation);
            return documentation;
        }

        public static string GetDocumentation(this PropertyInfo propertyInfo)
        {
            string key = "P:" + XmlDocumentationKeyHelper(
              propertyInfo.DeclaringType.FullName, propertyInfo.Name);
            loadedXmlDocumentation.TryGetValue(key, out string documentation);
            return documentation;
        }

        // Helper method to format the key strings
        private static string XmlDocumentationKeyHelper(
            string typeFullNameString, string memberNameString)
        {
            string key = Regex.Replace(
                typeFullNameString, @"\[.*\]", string.Empty).Replace('+', '.');

            if (memberNameString != null)
            {
                key += "." + memberNameString;
            }

            return key;
        }
    }
}
