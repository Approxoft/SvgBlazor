using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SvgBlazor.Docs.Extensions;

namespace SvgBlazor.Docs.Models
{
    public class ElementApiMethodExtractor
    {
        public Dictionary<string, ElementApiMethod> Extract(Type type)
        {
            var dict = new Dictionary<string, ElementApiMethod>();

            ListMethods(dict, type);

            Console.WriteLine("Finish! after merge");
            foreach (var d in dict)
            {
                Console.WriteLine(d.Key + " " + d.Value.Description);
            }

            return dict;
        }

        private void ListMethods(Dictionary<string, ElementApiMethod> dict, Type type)
        {
            foreach (var e in type.GetInterfaces())
            {
                Console.WriteLine("##Going to interface - start");
                ListMethods(dict, e);

                Console.WriteLine("Dict after merge");
                foreach (var d in dict)
                {
                    Console.WriteLine(d.Key + " " + d.Value.Description);
                }

                Console.WriteLine("##Going to interface - end");
            }

            if (type.BaseType is not null)
            {
                Console.WriteLine("##Going to base - start: " + type.BaseType.Name);
                ListMethods(dict, type.BaseType);
                Console.WriteLine("Dict after merge");
                foreach (var d in dict)
                {
                    Console.WriteLine(d.Key + " " + d.Value.Description);
                }

                Console.WriteLine("##Going to base - end: " + type.BaseType.Name);
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