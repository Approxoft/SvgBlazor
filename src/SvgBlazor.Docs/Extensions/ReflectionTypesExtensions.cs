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
        private static readonly Dictionary<string, string> LoadedXmlDocumentation = new ();

        private static readonly HashSet<Assembly> LoadedAssemblies = new ();

        public static void LoadXmlDocumentation(Assembly assembly)
        {
            if (LoadedAssemblies.Contains(assembly))
            {
                return;
            }

            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => x.Contains($"SvgBlazor.xml"));

            if (resourceName is null)
            {
                throw new Exception("Couldn't load documentation XML:" + resourceName);
            }

            using var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(resourceStream);

            LoadXmlDocumentation(reader.ReadToEnd());
            LoadedAssemblies.Add(assembly);
        }

        public static void LoadXmlDocumentation(string xmlDocumentation)
        {
            using XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocumentation));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    LoadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
                }
            }
        }

        public static string GetDocumentation(this Type type)
        {
            string key = "T:" + FormatKeyString(type.FullName, null);
            LoadedXmlDocumentation.TryGetValue(key, out string documentation);
            return StripXmlTags(documentation);
        }

        public static void ClearLoadedXmlDocumentation()
        {
            LoadedXmlDocumentation.Clear();
        }

        public static string GetDocumentation(this PropertyInfo propertyInfo)
        {
            string key = "P:" + FormatKeyString(propertyInfo.DeclaringType.FullName, propertyInfo.Name);
            LoadedXmlDocumentation.TryGetValue(key, out string documentation);
            return StripXmlTags(documentation);
        }

        public static string GetSignature(this MethodInfo methodInfo)
        {
            string parameters = GetParameterTypes(methodInfo);
            return $"{methodInfo.Name}({parameters})";
        }

        public static string GetDocumentation(this MethodInfo methodInfo)
        {
            string parameters = GetParameterTypes(methodInfo);

            string key = "M:"
                + FormatKeyString(methodInfo.DeclaringType.FullName, methodInfo.Name)
                + (parameters.Length == 0 ? string.Empty : $"({parameters})");

            LoadedXmlDocumentation.TryGetValue(key, out string documentation);

            return StripXmlTags(documentation);
        }

        private static string StripXmlTags(string xml)
        {
            return Regex.Replace(
                xml ?? string.Empty,
                @"<[^>]+>",
                string.Empty).Trim();
        }

        private static string GetParameterTypes(MethodInfo methodInfo)
        {
            var parametersTypes = methodInfo
                .GetParameters()
                .Select(x => x.ParameterType.FullName)
                .ToArray();

            return string.Join(",", parametersTypes);
        }

        private static string FormatKeyString(string typeFullNameString, string memberNameString)
        {
            string key = Regex.Replace(
                typeFullNameString,
                @"\[.*\]",
                string.Empty).Replace('+', '.');

            if (memberNameString != null)
            {
                key += "." + memberNameString;
            }

            return key;
        }
    }
}
