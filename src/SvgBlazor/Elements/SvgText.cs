// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgText class is responsible for providing the SVG text element.
    /// </summary>
    public class SvgText : SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgText"/> class.
        /// </summary>
        public SvgText()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgText"/> class with provided SvgText.
        /// </summary>
        /// <param name="svgtext">Initial SvgText.</param>
        public SvgText(SvgText svgtext)
            : base(svgtext)
        {
            Text = svgtext.Text;
            ShiftX = svgtext.ShiftX;
            ShiftY = svgtext.ShiftY;
            Rotate = svgtext.Rotate;
            LengthAdjust = svgtext.LengthAdjust;
            TextLength = svgtext.TextLength;
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets x-axis shift from the `X` coordinate.
        /// </summary>
        public SvgValue ShiftX { get; set; }

        /// <summary>
        /// Gets or sets y-axis shift from the `Y` coordinate.
        /// </summary>
        public SvgValue ShiftY { get; set; }

        /// <summary>
        /// Gets or sets rotation of each glyph.
        /// </summary>
        public string Rotate { get; set; }

        /// <summary>
        /// Gets or sets how the text should fit the length set in `TextLength` attribute.
        /// </summary>
        public TextLengthAdjust LengthAdjust { get; set; }

        /// <summary>
        /// Gets or sets width that the text should be scaled to fit.
        /// </summary>
        public SvgValue TextLength { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "text";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            builder.AddAttribute(2, "dx", ShiftX);
            builder.AddAttribute(3, "dy", ShiftY);
            builder.AddAttribute(4, "rotate", Rotate);
            builder.AddAttribute(5, "lengthAdjust", LengthAdjust.ToDescriptionString());
            builder.AddAttribute(6, "textLength", TextLength);

            builder.AddContent(7, Text);
        }
    }
}
