using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    public partial class SvgText : SvgElement, ISvgFillable
    {
        /// <summary>
        /// The child content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color of the text.
        /// </summary>
        public SvgFill Fill { get; set; } = new SvgFill();

        public override string Tag() => "text";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            Fill.RenderAttributes(builder);
            builder.AddContent(2, Text);
        }

        public override RectangleF BoundingRect() => throw new NotImplementedException();
    }
}
