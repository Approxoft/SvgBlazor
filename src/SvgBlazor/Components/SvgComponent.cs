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
        private readonly Svg svg = new Svg();

        public ISvgContainer SvgContainer => svg;

        private IJSObjectReference _module;

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
        /// Gets or sets the optional position x of the viewbox. Defaults to zero.
        /// </summary>
        [Parameter]
        public float? ViewBoxX { get; set; }

        /// <summary>
        /// Gets or sets the optional position y of the viewbox. Defaults to zero.
        /// </summary>
        [Parameter]
        public float? ViewBoxY { get; set; }

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
        public EventCallback<MouseEventArgs> OnClick
        {
            get => svg.OnClick;
            set => svg.OnClick = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseDown event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown
        {
            get => svg.OnMouseDown;
            set => svg.OnMouseDown = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseMove event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseMove
        {
            get => svg.OnMouseMove;
            set => svg.OnMouseMove = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseUp event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp
        {
            get => svg.OnMouseUp;
            set => svg.OnMouseUp = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseOver event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOver
        {
            get => svg.OnMouseOver;
            set => svg.OnMouseOver = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseOut event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOut
        {
            get => svg.OnMouseOut;
            set => svg.OnMouseOut = value;
        }

        /// <summary>
        /// Gets or sets the OnMouseEnter event callback.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseEnter
        {
            get => svg.OnMouseEnter;
            set => svg.OnMouseEnter = value;
        }

        // TODO: provide description
        [Parameter]
        public EventCallback<WheelEventArgs> OnWheel
        {
            get => svg.OnWheel;
            set => svg.OnWheel = value;
        }

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
             //await _module.DisposeAsync();
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
        /// <param name="refreshAfterRemoval">Should refresh be called after removal.</param>
        /// <returns>The container from which the element was removed.</returns>
        public ISvgContainer Remove(ISvgElement element, bool refreshAfterRemoval = true)
        {
            svg.Remove(element);

            if (refreshAfterRemoval)
            {
                Refresh();
            }

            return svg;
        }

        /// <summary>
        /// Gets the bounding box of the element.
        /// </summary>
        /// <param name="element">The element from which the bounding box dimension is taken.</param>
        /// <returns>The RectangleF with bounding box dimension.</returns>
        /// <exception cref="Exception">Thrown if no reference to the SvgBlazor.js object was loaded.</exception>
        public async Task<RectangleF> GetBoundingBox(ISvgElement element) // TODO: this should be removed
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
               // await LoadSvgBlazorJsModule(); // TODO: this should be removed
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            svg.Width = Width;
            svg.Height = Height;
            svg.ViewBoxHeight = ViewBoxHeight;
            svg.ViewBoxWidth = ViewBoxWidth;
            svg.ViewBoxX = ViewBoxX;
            svg.ViewBoxY = ViewBoxY;
        }

        /// <inheritdoc/>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, svg.Tag());
            svg.AddAttributes(builder);
            svg.BuildElementAdditionalSteps(builder);
            builder.CloseComponent();
        }

        //private async Task LoadSvgBlazorJsModule() => // TODO: this should be removed
        //    _module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/SvgBlazor/SvgBlazor.js");
    }
}
