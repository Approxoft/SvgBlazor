using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer: SvgElement, ISvgContainer
    {
        readonly List<SvgElement> elements = new();

        public ISvgContainer Add(SvgElement element)
        {
            element.SetParent(this);
            elements.Add(element);
            return this;
        }

        public ISvgContainer Remove(SvgElement element)
        {
            elements.Remove(element);
            return this;
        }
        public override void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            AddAttributes(builder);
            AddElements(builder);
            builder.CloseElement();
        }

        public virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in elements)
            {
                element.BuildElement(builder);
            }
        }

        public void ElementMouseOver(SvgElement element, MouseEventArgs args) =>
            Parent().ElementMouseOver(element, args);

        public void ElementMouseOut(SvgElement element, MouseEventArgs args) =>
            Parent().ElementMouseOut(element, args);
    }
}
