using System;
using System.Drawing;
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
        public SvgValue X1
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Start point y-axis coordinate.
        /// </summary>
        public SvgValue Y1
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// End point x-axis coordinate.
        /// </summary>
        public SvgValue X2 { get; set; }

        /// <summary>
        /// End point y-axis coordinate.
        /// </summary>
        public SvgValue Y2 { get; set; }

        public override string Tag() => "line";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x1", X1);
            builder.AddAttribute(1, "y1", Y1);
            builder.AddAttribute(2, "x2", X2);
            builder.AddAttribute(3, "y2", Y2);
        }

        public override RectangleF BoundingRect()
        {
            float x1 = Math.Min(X1, X2);
            float y1 = Math.Min(Y1, Y2);

            float width = Math.Abs(X2 - X1);
            float height = Math.Abs(X2 - X1);

            return new RectangleF(x1, y1, width, height);
        }
    }
}
