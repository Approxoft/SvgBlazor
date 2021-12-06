using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgFill determines how the interior of a given SVG element is painted.
    /// </summary>
    public class SvgFill
    {
        /// <summary>
        /// Gets or sets the paint used to render the interior of shapes. This can be a color, pattern or gradient (e.g. url(#pattern)).
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the opacity of the painting operation.
        /// </summary>
        public SvgValue Opacity { get; set; }

        /// <summary>
        /// Gets or sets the rule that determines which parts of the canvas are contained within the shape.
        /// </summary>
        public FillRule? Rule { get; set; }

        public void RenderAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "fill", Color);
            builder.AddAttribute(1, "fill-opacity", Opacity);
            builder.AddAttribute(2, "fill-rule", Rule?.ToDescriptionString());
        }
    }
}