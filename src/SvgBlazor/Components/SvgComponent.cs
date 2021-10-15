using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SvgBlazor.Interfaces;
using SvgBlazor.Interop;

namespace SvgBlazor
{
    public class SvgComponent : ComponentBase, ISvgComponent, IAsyncDisposable
    {
        private readonly SvgElementConnector svg;

        public IJSObjectReference Module { get; private set; }

        public SvgComponent() => svg = new (this);

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public float Width { get; set; }

        [Parameter]
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets the optional width of the viewbox. If not set, the `Width` value will be used.
        /// </summary>
        [Parameter]
        public float? ViewBoxWidth { get; set; }

        /// <summary>
        /// Gets or sets the optional height of the viewbox. If not set, the `Height` value will be used.
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

        public void Refresh() => StateHasChanged();

        public async ValueTask DisposeAsync() => await Module.DisposeAsync();

        public ISvgContainer Add(ISvgElement element)
        {
            svg.Add(element);
            ReassignBoundingBoxable();
            Refresh();
            return svg;
        }

        public ISvgContainer Remove(ISvgElement element)
        {
            svg.Remove(element);
            Refresh();
            return svg;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadModule();
            }
        }

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
            svg.BuildElementAdditionalSteps(builder);
            builder.CloseComponent();
        }

        private async Task LoadModule() => Module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./SvgBlazor.js");

        private void ReassignBoundingBoxable()
        {
            svg
                .GetElements()
                .ForEach(e => e.SetComponent(this));
        }
    }
}
