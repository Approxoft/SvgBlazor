// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgLine"/> class.
        /// </summary>
        public SvgLine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgLine"/> class with provided SvgLine.
        /// </summary>
        /// <param name="svgline">Initial SvgLine.</param>
        public SvgLine(SvgLine svgline)
            : base(svgline)
        {
            X1 = svgline.X1;
            Y1 = svgline.Y1;
            X2 = svgline.X2;
            Y2 = svgline.Y2;
        }

        /// <summary>
        /// Gets or sets start point x-axis coordinate.
        /// </summary>
        public SvgValue X1
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Gets or sets start point y-axis coordinate.
        /// </summary>
        public SvgValue Y1
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// Gets or sets the end point x-axis coordinate.
        /// </summary>
        public SvgValue X2 { get; set; }

        /// <summary>
        /// Gets or sets the end point y-axis coordinate.
        /// </summary>
        public SvgValue Y2 { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "line";

        /// <inheritdoc/>
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
