// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgRect class is responsible for providing the SVG rect element.
    /// </summary>
    public class SvgRect : SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgRect"/> class.
        /// </summary>
        public SvgRect()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgRect"/> class with provided SvgRect.
        /// </summary>
        /// <param name="svgrect">Initial SvgRect.</param>
        public SvgRect(SvgRect svgrect)
            : base(svgrect)
        {
            Width = svgrect.Width;
            Height = svgrect.Height;
            Rx = svgrect.Rx;
            Ry = svgrect.Ry;
        }

        /// <summary>
        /// Gets or sets the width of the rect.
        /// </summary>
        public SvgValue Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rect.
        /// </summary>
        public SvgValue Height { get; set; }

        /// <summary>
        /// Gets or sets the horizontal corner radius of the rect. Defaults to Ry (if specified).
        /// </summary>
        public SvgValue Rx { get; set; }

        /// <summary>
        /// Gets or sets the vertical corner radius of the rect. Defaults to Rx (if specified).
        /// </summary>
        public SvgValue Ry { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "rect";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            builder.AddAttribute(2, "width", Width);
            builder.AddAttribute(3, "height", Height);
            builder.AddAttribute(4, "rx", Rx);
            builder.AddAttribute(5, "ry", Ry);
        }
    }
}
