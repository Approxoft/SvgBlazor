using System;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgStroke class is responsible for providing the paint of the outline of an svg element.
    /// </summary>
    public class SvgStroke
    {
        /// <summary>
        /// The appearance of the Stroke. Can be color, pattern or gradient (e.g. url(#pattern)).
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The stroke dash array.
        /// </summary>
        public string DashArray { get; set; }

        /// <summary>
        /// The dash offset.
        /// </summary>
        public SvgValue DashOffset { get; set; }

        /// <summary>
        /// Sets the style of the stroke at the start and end of an open subpath.
        /// </summary>
        public StrokeLineCapStyle? LineCap { get; set; }

        /// <summary>
        /// Sets the appearance at the join point of two lines.
        /// </summary>
        public StrokeLineJoinStyle? LineJoin { get; set; }

        /// <summary>
        /// Sets the miter limit. Must be greater then or equal to 1.
        /// </summary>
        public int? MiterLimit { get; set; }

        /// <summary>
        /// Sets the opacity of the stroke.
        /// </summary>
        public SvgValue Opacity { get; set; }

        /// <summary>
        /// Sets the width of the stroke.
        /// </summary>
        public SvgValue Width { get; set; }

        public void RenderAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "stroke", Color);
            builder.AddAttribute(1, "stroke-dasharray", DashArray);
            builder.AddAttribute(2, "stroke-dashoffset", DashOffset);
            builder.AddAttribute(3, "stroke-linecap", LineCap?.ToDescriptionString());
            builder.AddAttribute(4, "stroke-linejoin", LineJoin?.ToDescriptionString());
            builder.AddAttribute(5, "stroke-miterlimit", MiterLimit);
            builder.AddAttribute(6, "stroke-opacity", Opacity);
            builder.AddAttribute(7, "stroke-width", Width);
        }
    }
}
