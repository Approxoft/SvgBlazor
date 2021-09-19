using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer: SvgElement, ISvgContainer
    {
        readonly List<SvgElement> elements = new();

        public ISvgContainer Add(SvgElement element)
        {
            elements.Add(element);
            return this;
        }

        public ISvgContainer Remove(SvgElement element)
        {
            elements.Remove(element);
            return this;
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
