using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer: SvgElement, ISvgContainer
    {
        readonly List<ISvgElement> elements = new();

        public ISvgContainer Add(ISvgElement element)
        {
            element.SetParent(this);
            elements.Add(element);
            return this;
        }

        public ISvgContainer Remove(ISvgElement element)
        {
            elements.Remove(element);
            return this;
        }

        public virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in elements)
            {
                element.BuildElement(builder);
            }
        }

        public override void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            AddElements(builder);
            builder.CloseElement();
        }
    }
}
