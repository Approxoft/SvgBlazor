using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace SvgBlazor.Docs.Models
{
    public class XmlDoc
    {
        private readonly Dictionary<string, string> _loadedXmlDocumentation = new ();

        private readonly HashSet<Assembly> _loadedAssemblies = new ();

        public XmlDoc()
        {
        }

        public XmlDoc(Assembly assembly)
        {
            LoadXmlDocumentation(assembly);
        }

        public XmlDoc(string xmlDocumentation)
        {
            LoadXmlDocumentation(xmlDocumentation);
        }

        public void LoadXmlDocumentation(Assembly assembly)
        {
            if (_loadedAssemblies.Contains(assembly))
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
            _loadedAssemblies.Add(assembly);
        }

        public void LoadXmlDocumentation(string xmlDocumentation)
        {
            using XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocumentation));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    _loadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
                }
            }
        }

        public string GetDocumentation(Type type)
        {
            string key = "T:" + FormatKeyString(type.FullName, null);
            _loadedXmlDocumentation.TryGetValue(key, out string documentation);
            return StripXmlTags(documentation);
        }

        public void ClearLoadedXmlDocumentation()
        {
            _loadedXmlDocumentation.Clear();
        }

        public string GetDocumentation(PropertyInfo propertyInfo)
        {
            string key = "P:" + FormatKeyString(propertyInfo.DeclaringType.FullName, propertyInfo.Name);
            _loadedXmlDocumentation.TryGetValue(key, out string documentation);
            return StripXmlTags(documentation);
        }

        public string GetSignature(MethodInfo methodInfo)
        {
            string parameters = GetParameterTypes(methodInfo);
            return $"{methodInfo.Name}({parameters})";
        }

        public string GetDocumentation(MethodInfo methodInfo)
        {
            string parameters = GetParameterTypes(methodInfo);

            string key = "M:"
                + FormatKeyString(methodInfo.DeclaringType.FullName, methodInfo.Name)
                + (parameters.Length == 0 ? string.Empty : $"({parameters})");

            _loadedXmlDocumentation.TryGetValue(key, out string documentation);

            return StripXmlTags(documentation);
        }

        private string StripXmlTags(string xml)
        {
            return Regex.Replace(
                xml ?? string.Empty,
                @"<[^>]+>",
                string.Empty).Trim();
        }

        private string GetParameterTypes(MethodInfo methodInfo)
        {
            var parametersTypes = methodInfo
                .GetParameters()
                .Select(x => x.ParameterType.FullName)
                .ToArray();

            return string.Join(",", parametersTypes);
        }

        private string FormatKeyString(string typeFullNameString, string memberNameString)
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
