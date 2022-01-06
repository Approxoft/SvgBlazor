using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using SvgBlazor.Docs.Models;

namespace SvgBlazor.Docs.Extensions
{
    public static class ReflectionTypesExtensions
    {
        private static readonly XmlDoc XmlDocumentation = new ();

        public static void LoadXmlDocumentation(Assembly assembly)
        {
            XmlDocumentation.LoadXmlDocumentation(assembly);
        }

        public static void LoadXmlDocumentation(string xmlDocumentation)
        {
            XmlDocumentation.LoadXmlDocumentation(xmlDocumentation);
        }

        public static string GetDocumentation(this Type type)
        {
            return XmlDocumentation.GetDocumentation(type);
        }

        public static void ClearLoadedXmlDocumentation()
        {
            XmlDocumentation.ClearLoadedXmlDocumentation();
        }

        public static string GetDocumentation(this PropertyInfo propertyInfo)
        {
            return XmlDocumentation.GetDocumentation(propertyInfo);
        }

        public static string GetSignature(this MethodInfo methodInfo)
        {
            return XmlDocumentation.GetSignature(methodInfo);
        }

        public static string GetDocumentation(this MethodInfo methodInfo)
        {
            return XmlDocumentation.GetDocumentation(methodInfo);
        }

        public static XmlDoc GetXmlDoc()
        {
            return XmlDocumentation;
        }
    }
}
