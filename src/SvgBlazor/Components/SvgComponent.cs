using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    class SvgAdapter: Svg
    {
        public bool MouseDown { get; set; } = false;
        public ISvgElement OverElement { get; set; }
        public SvgComponent SvgComponent { get; set; }

        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
        {
            if (MouseDown)
            {
                return;
            }

            if (element is not ISvgContainer)
            {
                OverElement = element;
            }
        }

        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (MouseDown)
            {
                return;
            }

            if (element is not ISvgContainer)
            {
                OverElement = null;
            }
        }

        public override void Refresh()
        {
            SvgComponent.Refresh();
        }
    }

    public class SvgComponent: ComponentBase
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

        private readonly SvgAdapter svg = new();

        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            BuildElement(builder);
        }

        public virtual void BuildElement(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, svg.Tag());
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

        public virtual void SetOnClick(Action<MouseEventArgs> action)
        {
            OnClick = EventCallback.Factory.Create<MouseEventArgs>(this, action);
        }

        public void Refresh() => StateHasChanged();

        public ISvgContainer Add(ISvgElement element)
        {
            svg.Add(element);
            Refresh();
            return svg;
        }

        public ISvgContainer Remove(ISvgElement element)
        {
            svg.Remove(element);
            Refresh();
            return svg;
        }

        public async Task OnClickHandler(MouseEventArgs args)
        {
            svg.OverElement?.OnClickHandler(args);
            await OnClick.InvokeAsync();
        }

        public async Task OnMouseDownHandler(MouseEventArgs args)
        {
            svg.MouseDown = true;
            svg.OverElement?.OnMouseDownHandler(args);
            await OnMouseDown.InvokeAsync();
        }

        public async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            svg.OverElement?.OnMouseMoveHandler(args);
            await OnMouseMove.InvokeAsync();
        }

        public async Task OnMouseUpHandler(MouseEventArgs args)
        {
            svg.MouseDown = false;
            svg.OverElement?.OnMouseUpHandler(args);
            await OnMouseUp.InvokeAsync();
        }
    }
}
