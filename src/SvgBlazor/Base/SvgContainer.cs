using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public abstract class SvgContainer : SvgElement, ISvgContainer
    {
        private readonly List<ISvgElement> _elements = new ();

        public bool MouseDown { get; private set; } = false;

        public ISvgElement OverElement { get; private set; }

        public ISvgContainer Add(ISvgElement element)
        {
            element.SetParent(this);
            _elements.Add(element);
            return this;
        }

        public ISvgContainer Remove(ISvgElement element)
        {
            _elements.Remove(element);
            return this;
        }

        protected virtual void AddElements(RenderTreeBuilder builder)
        {
            foreach (var element in _elements)
            {
                element.BuildElement(builder);
            }
        }

        public override void BuildElementAdditionalSteps(RenderTreeBuilder builder) => AddElements(builder);

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
