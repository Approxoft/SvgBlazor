﻿using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// SVG rect element.
    /// </summary>
    public class SvgRect : SvgElement, ISvgFillable
    {
        /// <summary>
        /// The width of the rect.
        /// </summary>
        public SvgValue Width { get; set; }

        /// <summary>
        /// The height of the rect.
        /// </summary>
        public SvgValue Height { get; set; }

        /// <summary>
        /// The horizontal corner radius of the rect. Defaults to Ry (if specified).
        /// </summary>
        public SvgValue Rx { get; set; }

        /// <summary>
        /// The vertical corner radius of the rect. Defaults to Rx (if specified).
        /// </summary>
        public SvgValue Ry { get; set; }

        /// <summary>
        /// The fill color of the rectangle.
        /// </summary>
        public SvgFill Fill { get; set; } = new SvgFill();

        public override string Tag() => "rect";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            builder.AddAttribute(2, "width", Width);
            builder.AddAttribute(3, "height", Height);
            builder.AddAttribute(4, "rx", Rx);
            builder.AddAttribute(5, "ry", Ry);

            Fill.RenderAttributes(builder);
        }

        public override RectangleF BoundingRect() => new RectangleF(X, Y, Width, Height);
    }
}
