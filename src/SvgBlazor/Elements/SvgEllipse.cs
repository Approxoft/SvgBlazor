using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public class SvgEllipse : SvgElement
    {
        /// <summary>
        /// The x-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterX { get; set; }

        /// <summary>
        /// The y-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterY { get; set; }

        /// <summary>
        /// The radius on the x axis.
        /// </summary>
        public SvgValue RadiusX { get; set; }

        /// <summary>
        /// The radius on the y axis.
        /// </summary>
        public SvgValue RadiusY { get; set; }

        public override string Tag() => "ellipse";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "cx", CenterX);
            builder.AddAttribute(1, "cy", CenterY);
            builder.AddAttribute(2, "rx", RadiusX);
            builder.AddAttribute(3, "ry", RadiusY);
        }
    }
}
