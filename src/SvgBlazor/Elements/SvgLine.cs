using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgLine class is responsible for providing the SVG line element.
    /// </summary>
    public partial class SvgLine : SvgElement
    {
        public SvgLine()
        {
        }

        public SvgLine(SvgLine svgline)
            : base(svgline)
        {
            X1 = svgline.X1;
            Y1 = svgline.Y1;
            X2 = svgline.X2;
            Y2 = svgline.Y2;
        }

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
    }
}
