using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public partial class SvgLine : SvgElement
    {
        /// <summary>
        /// Start point x-axis coordinate.
        /// </summary>
        public SvgValue X1 { get; set; }

        /// <summary>
        /// Start point y-axis coordinate.
        /// </summary>
        public SvgValue Y1 { get; set; }

        /// <summary>
        /// End point x-axis coordinate.
        /// </summary>
        public SvgValue X2 { get; set; }

        /// <summary>
        /// End point y-axis coordinate.
        /// </summary>
        public SvgValue Y2 { get; set; }

        /// <summary>
        /// The color used to paint the outline of the shape.
        /// </summary>
        public string Stroke { get; set; } = "black";

        public override string Tag() => "line";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x1", X1);
            builder.AddAttribute(1, "y1", Y1);
            builder.AddAttribute(2, "x2", X2);
            builder.AddAttribute(3, "y2", Y2);
            builder.AddAttribute(4, "stroke", Stroke);
        }
    }
}
