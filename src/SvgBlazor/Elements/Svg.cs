using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    // TODO: use dynamic content for .net6
    /// <summary>
    /// The root class for svg drawings
    /// </summary>
    public partial class Svg : SvgContainer
    {
        public double Width { get; set; }

        public double Height { get; set; }

        /// <summary>
        /// The optional width of the viewbox. If not set, the `Width` value will be used
        /// </summary>
        public double? ViewBoxWidth { get; set; }

        /// <summary>
        /// The optional height of the viewbox. If not set, the `Height` value will be used
        /// </summary>
        public double? ViewBoxHeight { get; set; }


        public override string Tag() => "svg";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(1, "viewBox", string.Format("0 0 {0} {1}", ViewBoxWidth ?? Width, ViewBoxHeight ?? Height)); // TODO: do better
            builder.AddAttribute(2, "width", Width);
            builder.AddAttribute(3, "height", Height);
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
        }
    }
}
