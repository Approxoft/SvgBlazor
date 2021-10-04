using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
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

        public bool MouseDown { get; private set; } = false;

        public ISvgElement OverElement { get; private set; }

        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (element != this)
            {
                OverElement = element;
            }

            base.ElementMouseOver(this, args);
        }

        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (element != this)
            {
                OverElement = null;
            }

            base.ElementMouseOut(this, args);
        }

        public override async Task OnClickHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                await OverElement.OnClickHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            MouseDown = true;
            if (OverElement is not null)
            {
                await OverElement.OnMouseDownHandler(args);
                await base.OnMouseDownHandler(args);
            }
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            if (OverElement is not null)
            {
                await OverElement.OnMouseMoveHandler(args);
                await base.OnMouseMoveHandler(args);
            }
        }

        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            MouseDown = false;
            await (OverElement?.OnMouseUpHandler(args) ?? Task.CompletedTask);
            await base.OnMouseUpHandler(args);
        }
    }
}
