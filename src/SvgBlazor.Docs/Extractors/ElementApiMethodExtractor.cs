using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SvgBlazor.Docs.Extensions;
using SvgBlazor.Docs.Models;

namespace SvgBlazor.Docs.Extractors
{
    public class ElementApiMethodExtractor
    {
        public IEnumerable<ElementApiMethod> Extract(Type type)
        {
            var dict = new Dictionary<string, ElementApiMethod>();

            ExtractMethods(dict, type);

            return dict.Select(p => p.Value);
        }

        private void ExtractMethods(Dictionary<string, ElementApiMethod> dict, Type type)
        {
            foreach (var e in type.GetInterfaces())
            {
                ExtractMethods(dict, e);
            }

            if (type.BaseType is not null)
            {
                ExtractMethods(dict, type.BaseType);
            }

            foreach (var methodInfo in type.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public).Where(m => !m.IsSpecialName))
            {
                AddOrReplaceEntry(dict, methodInfo);
            }
        }

        private void AddOrReplaceEntry(
            Dictionary<string, ElementApiMethod> dictionary,
            MethodInfo methodInfo)
        {
            var signature = methodInfo.GetSignature();
            var element = GetElementApiMethod(methodInfo);

            if ((dictionary.ContainsKey(signature) && !string.IsNullOrWhiteSpace(element.Description)) ||
                !dictionary.ContainsKey(signature))
            {
                dictionary[signature] = element;
            }
        }

        private ElementApiMethod GetElementApiMethod(MethodInfo info) =>
            new ElementApiMethod
            {
                Name = info.Name,
                Parameters = ParametersToString(info.GetParameters()),
                ReturnValue = info.ReturnType.Name,
                Description = info.GetDocumentation(),
            };

        private IEnumerable<string> ParametersToString(ParameterInfo[] parameters) =>
            parameters.Select(x => x.ParameterType.FullName + " " + x.Name).ToArray();
    }
}