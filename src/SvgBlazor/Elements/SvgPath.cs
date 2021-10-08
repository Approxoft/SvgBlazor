using System;
using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Elements
{
    /// <summary>
    /// The path element.
    /// </summary>
    public class SvgPath : SvgElement
    {
        /// <summary>
        /// Gets or sets the d string representing the actual path.
        /// </summary>
        public string Path { get; set; }

        public override RectangleF BoundingRect() => throw new NotImplementedException();

        public override string Tag() => "path";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);

            builder.AddAttribute(0, "d", Path);
        }
    }
}
