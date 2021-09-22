using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG polygon element.
    /// </summary>
    public class SvgPolygon : SvgElement
    {
        /// <summary>
        /// The list of points (pairs of x,y absolute coordinates) required to draw the polygon.
        /// </summary>
        public string Points { get; set; }

        /// <summary>
        /// The color used to paint the outline of the shape.
        /// </summary>
        public string Stroke { get; set; }

        public override string Tag() => "polygon";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "points", Points);
            builder.AddAttribute(1, "stroke", Stroke);
        }
    }
}
