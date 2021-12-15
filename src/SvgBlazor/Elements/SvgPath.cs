using System;
using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgPath class is responsible for providing the SVG path element.
    /// </summary>
    public class SvgPath : SvgElement
    {
        public SvgPath()
        {
        }

        public SvgPath(SvgPath svgpath)
            : base(svgpath)
        {
            Path = svgpath.Path;
        }

        /// <summary>
        /// Gets or sets the d string representing the actual path.
        /// </summary>
        public string Path { get; set; }

        public override string Tag() => "path";

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);

            builder.AddAttribute(0, "d", Path);
        }
    }
}
