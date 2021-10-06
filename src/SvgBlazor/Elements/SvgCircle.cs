using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

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
        public SvgValue CenterX
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// The y-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterY
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public SvgValue Radius { get; set; }

        public override string Tag() => "circle";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "cx", X);
            builder.AddAttribute(1, "cy", Y);
            builder.AddAttribute(2, "r", Radius);
        }

        public override RectangleF BoundingRect()
        {
            float size = Radius * 2f;
            return new RectangleF(
                CenterX - Radius,
                CenterY - Radius,
                size,
                size);
        }
    }
}
