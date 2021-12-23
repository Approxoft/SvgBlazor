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
        public IEnumerable<ElementApiMethod> ExtractMethods(Type type)
        {
            var dict = new Dictionary<string, ElementApiMethod>();

            Get(dict, type, () =>
            {
                foreach (var methodInfo in type.GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.Public).Where(m => !m.IsSpecialName))
                {
                    var signature = methodInfo.GetSignature();
                    var element = GetElementApiMethod(methodInfo);
                    AddOrReplaceEntry(signature, dict, element);
                }
            });

            return dict.Select(p => p.Value);
        }

        private void Get<T>(Dictionary<string, T> dict, Type type, Action action)
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

            action?.Invoke();
        }

        private void AddOrReplaceEntry<T>(
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