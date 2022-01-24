// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgCircle class is responsible for providing the SVG circle element.
    /// </summary>
    public class SvgCircle : SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgCircle"/> class.
        /// </summary>
        public SvgCircle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgCircle"/> class with provided SvgCircle.
        /// </summary>
        /// <param name="svgcircle">Initial SvgCircle.</param>
        public SvgCircle(SvgCircle svgcircle)
            : base(svgcircle)
        {
            CenterX = svgcircle.CenterX;
            CenterY = svgcircle.CenterY;
            Radius = svgcircle.Radius;
        }

        /// <summary>
        /// Gets or sets the x-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterX
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the center of the circle.
        /// </summary>
        public SvgValue CenterY
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public SvgValue Radius { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "circle";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "cx", X);
            builder.AddAttribute(1, "cy", Y);
            builder.AddAttribute(2, "r", Radius);
        }
    }
}
