// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
        private static readonly XmlDoc XmlDocumentation = new (Assembly.GetExecutingAssembly());

        public static string GetDocumentation(this Type type) =>
            XmlDocumentation.GetDocumentation(type);

        public static string GetDocumentation(this PropertyInfo propertyInfo) =>
            XmlDocumentation.GetDocumentation(propertyInfo);

        public static string GetSignature(this MethodInfo methodInfo) =>
            XmlDocumentation.GetSignature(methodInfo);

        public static string GetDocumentation(this MethodInfo methodInfo) =>
            XmlDocumentation.GetDocumentation(methodInfo);

        public static XmlDoc GetXmlDoc() => XmlDocumentation;
    }
}
