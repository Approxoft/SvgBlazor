using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer: SvgElement, ISvgContainer
    {
        readonly List<SvgElement> elements = new();

        public void Add(SvgElement element)
        {
            elements.Add(element);
        }

        public void Remove(SvgElement element)
        {
            elements.Remove(element);
        }

        public override void AddElements(RenderTreeBuilder builder)
        {
            base.AddElements(builder);
            foreach (var element in elements)
            {
                element.BuildElement(builder);
            }
        }
    }
}
