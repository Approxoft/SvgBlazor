using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer: SvgElement, ISvgContainer
    {
        public List<ISvgElement> Elements { get; set; } = new();

        public ISvgLayout Layout { get; set; }

        public ISvgContainer Add(ISvgElement element)
        {
            element.SetParent(this);
            Elements.Add(element);
            return this;
        }

        public void UpdateLayout()
        {
            // update the layout? + get elements (containers) and update their layout as well
        }

        public ISvgContainer Remove(ISvgElement element)
        {
            Elements.Remove(element);
            return this;
        }

        public virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in Elements)
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
