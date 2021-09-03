using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Elements
{
    // TODO: use dynamic content for .net6
    /// <summary>
    /// The root class for svg drawings
    /// </summary>
    public class Svg : ComponentBase
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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "svg");
            builder.AddAttribute(1, "viewBox", string.Format("0 0 {0} {1}", ViewBoxWidth ?? Width, ViewBoxHeight ?? Height)); // TODO: do better
            builder.AddAttribute(2, "width", Width);
            builder.AddAttribute(3, "height", Height);
            builder.AddContent(4, ChildContent);
            builder.CloseComponent();
        }

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
