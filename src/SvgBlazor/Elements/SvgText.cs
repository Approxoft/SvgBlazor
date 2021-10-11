using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;

namespace SvgBlazor
{
    /// <summary>
    /// SVG text element.
    /// </summary>
    public class SvgText : SvgElement
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets x-axis offset from the `X` coordinate.
        /// </summary>
        public SvgValue DX { get; set; }

        /// <summary>
        /// Gets or sets y-axis offset from the `Y` coordinate.
        /// </summary>
        public SvgValue DY { get; set; }

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

        public override string Tag() => "text";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            builder.AddAttribute(2, "dx", DX);
            builder.AddAttribute(3, "dy", DY);
            builder.AddAttribute(4, "rotate", Rotate);
            builder.AddAttribute(5, "lengthAdjust", LengthAdjust.ToStringValue());
            builder.AddAttribute(6, "textLength", TextLength);

            builder.AddContent(7, Text);
        }

        public override RectangleF BoundingRect() => throw new NotImplementedException();
    }
}
