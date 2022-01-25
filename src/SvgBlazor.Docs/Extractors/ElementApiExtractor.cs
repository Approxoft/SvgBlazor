// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SvgBlazor.Docs.Models;

namespace SvgBlazor.Docs.Extractors
{
    public class ElementApiExtractor
    {
        private static readonly List<string> SignaturesToFilterOut = new List<string>
        {
            "GetType()",
            "ToString()",
            "Equals(System.Object)",
            "Equals(System.Object,System.Object)",
            "ReferenceEquals(System.Object,System.Object)",
            "GetHashCode()",
        };

        private readonly XmlDoc _xmlDoc;

        public ElementApiExtractor(XmlDoc xmlDoc) => _xmlDoc = xmlDoc;

        public IEnumerable<ElementApiMethod> ExtractApiMethods(Type type)
        {
            var dict = new Dictionary<string, ElementApiMethod>();

            Get(dict, type, t =>
            {
                foreach (var methodInfo in t.GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.Public).Where(m => !m.IsSpecialName))
                {
                    var signature = _xmlDoc.GetSignature(methodInfo);
                    if (SignaturesToFilterOut.Contains(signature))
                    {
                        continue;
                    }

                    var element = GetElementApiMethod(methodInfo);

                    AddOrReplaceEntry(signature, dict, element);
                }
            });

            return dict.Select(p => p.Value);
        }

        public IEnumerable<ElementApiProperty> ExtractApiProperties(Type type)
        {
            var dict = new Dictionary<string, ElementApiProperty>();

            Get(dict, type, t =>
            {
                foreach (var propertyInfo in t.GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.Public))
                {
                    var name = propertyInfo.Name;
                    var element = GetElementApiProperty(propertyInfo);

                    AddOrReplaceEntry(name, dict, element);
                }
            });

            return dict.Select(p => p.Value);
        }

        private static void Get<T>(Dictionary<string, T> dict, Type type, Action<Type> action)
            where T : IElementApiElement
        {
            foreach (var e in type.GetInterfaces())
            {
                Get(dict, e, action);
            }

            if (type.BaseType is not null)
            {
                Get(dict, type.BaseType, action);
            }

            action?.Invoke(type);
        }

        private static void AddOrReplaceEntry<T>(
            string key,
            Dictionary<string, T> dictionary,
            T element)
            where T : IElementApiElement
        {
            if ((dictionary.ContainsKey(key) && !string.IsNullOrWhiteSpace(element.Description)) ||
                !dictionary.ContainsKey(key))
            {
                dictionary[key] = element;
            }
        }

        private static IEnumerable<string> ParametersToString(ParameterInfo[] parameters) =>
            parameters.Select(x => x.ParameterType.Name + " " + x.Name).ToArray();

        private ElementApiMethod GetElementApiMethod(MethodInfo info) =>
            new ()
            {
                Name = info.Name,
                Parameters = ParametersToString(info.GetParameters()),
                ReturnValue = info.ReturnType.Name,
                Description = _xmlDoc.GetDocumentation(info),
            };

        private ElementApiProperty GetElementApiProperty(PropertyInfo propertyInfo) =>
            new ()
            {
                Name = propertyInfo.Name,
                Type = propertyInfo.PropertyType.Name,
                DeclaringType = propertyInfo.DeclaringType.Name,
                Description = _xmlDoc.GetDocumentation(propertyInfo),
            };
    }
}