using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public partial class SvgText : SvgElement
    {
        /// <summary>
        /// The x coordinate of the starting point of the text baseline.
        /// </summary>
        public SvgValue X { get; set; }

        /// <summary>
        /// The y coordinate of the starting point of the text baseline.
        /// </summary>
        public SvgValue Y { get; set; }

        /// <summary>
        /// The child content.
        /// </summary>
        public string Text { get; set; }

        public override string Tag() => "text";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(0, "x", X);
            builder.AddAttribute(1, "y", Y);
            builder.AddContent(2, Text);
        }
    }
}
