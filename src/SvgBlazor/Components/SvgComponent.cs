using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public class SvgComponent: ComponentBase, ISvgContainer
    {
        [Parameter]
        public double Width { get; set; }

        [Parameter]
        public double Height { get; set; }

        /// <summary>
        /// The optional width of the viewbox. If not set, the `Width` value will be used
        /// </summary>
        [Parameter]
        public double? ViewBoxWidth { get; set; }

        /// <summary>
        /// The optional height of the viewbox. If not set, the `Height` value will be used
        /// </summary>
        [Parameter]
        public double? ViewBoxHeight { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private SvgElement _overElement;

        private bool _mouseDown = false;

        private readonly Svg svg = new();

        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;

            svg.SetParent(this);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "svg");
            var onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler);
            builder.AddAttribute(1, "onclick", onClickHandler);

            var onMouseDownHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseDownHandler);
            builder.AddAttribute(2, "onmousedown", onMouseDownHandler);

            var onMouseMoveHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseMoveHandler);
            builder.AddAttribute(3, "onmousemove", onMouseMoveHandler);

            var onMouseUpHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseUpHandler);
            builder.AddAttribute(4, "onmouseup", onMouseUpHandler);

            svg.AddAttributes(builder);
            svg.AddElements(builder);
            builder.CloseComponent();
        }

        public ISvgContainer Add(SvgElement element)
        {
            element.SetParent(this);
            svg.Add(element);
            Refresh();
            return this;
        }

        public ISvgContainer Remove(SvgElement element)
        {
            svg.Remove(element);
            Refresh();
            return this;
        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void ElementMouseOver(SvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element is not ISvgContainer)
            {
                _overElement = element;
            }
        }

        public void ElementMouseOut(SvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }
            _overElement = null;    
        }

        public void OnClickHandler(MouseEventArgs args)
        {
            _overElement?.OnClickHandler(args);
        }

        public void OnMouseDownHandler(MouseEventArgs args)
        {
            _overElement?.OnMouseDownHandler(args);
            _mouseDown = true;
        }

        public void OnMouseMoveHandler(MouseEventArgs args)
        {
            _overElement?.OnMouseMoveHandler(args);
        }

        public void OnMouseUpHandler(MouseEventArgs args)
        {
            _overElement?.OnMouseUpHandler(args);
            _mouseDown = false;
        }
    }
}
