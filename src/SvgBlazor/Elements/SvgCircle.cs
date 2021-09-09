using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public class SvgCircle : SvgElement
    {
        /// <summary>
        /// The x-axis coordinate of the center of the circle.
        /// </summary>
        [Parameter] public SvgValue CenterX { get; set; }

        /// <summary>
        /// The y-axis coordinate of the center of the circle.
        /// </summary>
        [Parameter] public SvgValue CenterY { get; set; }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        [Parameter] public SvgValue Radius { get; set; }

        protected override string Tag()
        {
            return "circle";
        }

        protected override void AddAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(10, "cx", CenterX);
            builder.AddAttribute(11, "cy", CenterY);
            builder.AddAttribute(12, "r", Radius);
        }
    }
}
