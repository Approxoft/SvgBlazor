using System;
using System.Threading.Tasks;
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
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

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
            BuildElement(builder);
        }

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag());
            var onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler);
            builder.AddAttribute(1, "onclick", onClickHandler);

            var onMouseDownHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseDownHandler);
            builder.AddAttribute(2, "onmousedown", onMouseDownHandler);

            var onMouseMoveHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseMoveHandler);
            builder.AddAttribute(3, "onmousemove", onMouseMoveHandler);

            var onMouseUpHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseUpHandler);
            builder.AddAttribute(4, "onmouseup", onMouseUpHandler);

            AddAttributes(builder);
            AddElements(builder);
            builder.CloseComponent();
        }
        public void AddElements(RenderTreeBuilder builder)
        {
            svg.AddElements(builder);
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

        public void Refresh() => StateHasChanged();

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

        public async Task OnClickHandler(MouseEventArgs args)
        {
            _overElement?.OnClickHandler(args);
            await OnClick.InvokeAsync();
        }

        public async Task OnMouseDownHandler(MouseEventArgs args)
        {
            _mouseDown = true;
            _overElement?.OnMouseDownHandler(args);
            await OnMouseDown.InvokeAsync();
        }

        public async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            _overElement?.OnMouseMoveHandler(args);
            await OnMouseMove.InvokeAsync();
        }

        public async Task OnMouseUpHandler(MouseEventArgs args)
        {
            _mouseDown = false;
            _overElement?.OnMouseUpHandler(args);
            await OnMouseUp.InvokeAsync();
        }

        public string Tag()
        {
            return "svg";
        }

        public void AddAttributes(RenderTreeBuilder builder)
        {
            svg.AddAttributes(builder);
        }

        public void SetParent(ISvgContainer parent)
        {
            throw new Exception("Can not set parent! It is a top most element.");
        }

        public ISvgContainer Parent()
        {
            return null;
        }
    }
}
