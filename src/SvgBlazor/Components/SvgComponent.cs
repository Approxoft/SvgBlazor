// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
    /// <summary>
    /// SvgComponent is the main class of the library. It provides a context for displaying basic SVG elements.
    /// </summary>
    /// <remarks>
    /// SvgComponent also allows direct display of content between SvgComponent tags but this is just
    /// a convenience for the user. The main idea of both the component and the library is to allow
    /// creating and operating on svg elements directly from C# code.
    /// </remarks>
    public class SvgComponent : ComponentBase, IAsyncDisposable
    {
        private readonly SvgElementConnector svg;
        private IJSObjectReference _module;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgComponent"/> class.
        /// </summary>
        public SvgComponent() => svg = new (this);

        /// <summary>
        /// Gets or sets the width of the svg element.
        /// </summary>
        [Parameter]
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the svg element.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the OnClick event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseDown event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseMove event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        /// <summary>
        /// Gets or sets the OnMouseUp event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        /// <summary>
        /// Gets or sets the child content of the component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Refreshes the state of the component. When applicable, this will cause the component to be re-rendered.
        /// </summary>
        public void Refresh() => StateHasChanged();

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
             await _module.DisposeAsync();
        }

        /// <summary>
        /// Adds the given element to the SvgComponent.
        /// </summary>
        /// <param name="element">Element to be added.</param>
        /// <returns>The container to which the element was added.</returns>
        public ISvgContainer Add(ISvgElement element)
        {
            svg.Add(element);
            Refresh();
            return svg;
        }

        /// <summary>
        /// Removes the given element from the SvgComponent.
        /// </summary>
        /// <param name="element">Element to be removed.</param>
        /// <returns>The container from which the element was removed.</returns>
        public ISvgContainer Remove(ISvgElement element)
        {
            svg.Remove(element);
            Refresh();
            return svg;
        }

        /// <summary>
        /// Gets the bounding box of the element.
        /// </summary>
        /// <param name="element">The element from which the bounding box dimension is taken.</param>
        /// <returns>The RectangleF with bounding box dimension.</returns>
        /// <exception cref="Exception">Thrown if no reference to the SvgBlazor.js object was loaded.</exception>
        public async Task<RectangleF> GetBoundingBox(ISvgElement element)
        {
            if (_module is null)
            {
                throw new Exception("Sorry, getting the bounding box is only available after the first render.");
            }

            return await _module
                .InvokeAsync<RectangleF>("BBox", element.ElementReference);
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadSvgBlazorJsModule();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;
        }

        /// <inheritdoc/>
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
            svg.BuildElementAdditionalSteps(builder);
            builder.CloseComponent();
        }

        private async Task LoadSvgBlazorJsModule() =>
            _module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/SvgBlazor/SvgBlazor.js");
    }
}
