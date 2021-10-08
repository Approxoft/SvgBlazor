using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The root class for svg drawings.
    /// </summary>
    public partial class Svg : SvgContainer
    {
        public float Width { get; set; }

        public float Height { get; set; }

        /// <summary>
        /// Gets or sets the optional width of the viewbox. If not set, the 'Width' value will be used.
        /// </summary>
        public float? ViewBoxWidth { get; set; }

        /// <summary>
        /// Gets or sets the optional height of the viewbox. If not set, the 'Height' value will be used.
        /// </summary>
        public float? ViewBoxHeight { get; set; }

        public override string Tag() => "svg";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(1, "viewBox", string.Format("0 0 {0} {1}", ViewBoxWidth ?? Width, ViewBoxHeight ?? Height));
            builder.AddAttribute(2, "width", Width);
            builder.AddAttribute(3, "height", Height);
        }

        /// <summary>
        /// Sets the size of the viewbox and redraws the svg.
        /// </summary>
        /// <param name="width">Width of the viewbox.</param>
        /// <param name="height">Height of the viewbox.</param>
        public void SetViewBox(float width, float height)
        {
            ViewBoxWidth = width;
            ViewBoxHeight = height;
        }

        /// <summary>
        /// Sets the size of the viewport and redraws the svg.
        /// </summary>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        public void SetSize(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public override RectangleF BoundingRect() => new (X, Y, Width, Height);
    }
}
