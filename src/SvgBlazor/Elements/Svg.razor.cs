using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    // TODO: use dynamic content for .net6
    /// <summary>
    /// The root class for svg drawings
    /// </summary>
    public partial class Svg : SvgElementBase
    {
        [Parameter]
        public double Width { get; set; }

        [Parameter]
        public double Height { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

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

        /// <summary>
        /// Sets the size of the viewbox and redraws the svg
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetViewBox(double width, double height)
        {
            ViewBoxWidth = width;
            ViewBoxHeight = height;

            Refresh();
        }

        /// <summary>
        /// Sets the size of the viewport and redraws the svg
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(double width, double height)
        {
            Width = width;
            Height = height;

            Refresh();
        }

        /// <summary>
        /// Redraws the svg
        /// </summary>
        public void Refresh()
        {
            StateHasChanged();
        }
    }
}
