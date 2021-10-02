using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    class SvgElementConnector: Svg
    {
        private bool _mouseDown = false;
        private ISvgElement _overElement;
        private readonly SvgComponent _svgComponent;

        public SvgElementConnector(SvgComponent component)
        {
            _svgComponent = component;
        }

        public override void ElementMouseOver(ISvgElement element, MouseEventArgs args)
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

        public override void ElementMouseOut(ISvgElement element, MouseEventArgs args)
        {
            if (_mouseDown)
            {
                return;
            }

            if (element is not ISvgContainer)
            {
                _overElement = null;
            }
        }

        public override void Refresh() => _svgComponent.Refresh();

        public override async Task OnClickHandler(MouseEventArgs args)
        {
            await (_overElement?.OnClickHandler(args) ?? Task.CompletedTask);
            await _svgComponent.OnClick.InvokeAsync();
        }

        public override async Task OnMouseDownHandler(MouseEventArgs args)
        {
            _mouseDown = true;
            await (_overElement?.OnMouseDownHandler(args) ?? Task.CompletedTask);
            await _svgComponent.OnMouseDown.InvokeAsync();
        }

        public override async Task OnMouseMoveHandler(MouseEventArgs args)
        {
            await (_overElement?.OnMouseMoveHandler(args) ?? Task.CompletedTask);
            await _svgComponent.OnMouseMove.InvokeAsync();
        }

        public override async Task OnMouseUpHandler(MouseEventArgs args)
        {
            _mouseDown = false;
            await (_overElement?.OnMouseUpHandler(args) ?? Task.CompletedTask);
            await _svgComponent.OnMouseUp.InvokeAsync();
        }
    }

    public class SvgComponent: ComponentBase
    {
        [Parameter]
        public float Width { get; set; }

        [Parameter]
        public float Height { get; set; }

        /// <summary>
        /// The optional width of the viewbox. If not set, the `Width` value will be used
        /// </summary>
        [Parameter]
        public float? ViewBoxWidth { get; set; }

        /// <summary>
        /// The optional height of the viewbox. If not set, the `Height` value will be used
        /// </summary>
        [Parameter]
        public float? ViewBoxHeight { get; set; }

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

        private readonly SvgElementConnector svg;

        public SvgComponent() => svg = new(this);

        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, svg.Tag());
            var onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, svg.OnClickHandler);
            builder.AddAttribute(1, "onclick", onClickHandler);

            var onMouseDownHandler = EventCallback.Factory.Create<MouseEventArgs>(this, svg.OnMouseDownHandler);
            builder.AddAttribute(2, "onmousedown", onMouseDownHandler);

            var onMouseMoveHandler = EventCallback.Factory.Create<MouseEventArgs>(this, svg.OnMouseMoveHandler);
            builder.AddAttribute(3, "onmousemove", onMouseMoveHandler);

            var onMouseUpHandler = EventCallback.Factory.Create<MouseEventArgs>(this, svg.OnMouseUpHandler);
            builder.AddAttribute(4, "onmouseup", onMouseUpHandler);

            svg.AddAttributes(builder);
            svg.AddElements(builder);
            builder.CloseComponent();
        }

        public void Refresh()
        {
            svg.Elements
                .OfType<ISvgContainer>()
                .ToList()
                .ForEach(c => c.UpdateLayout());
            StateHasChanged();
        }

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
    }
}
