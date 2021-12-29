using System;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgStroke class is responsible for providing the paint of the outline of an svg element.
    /// </summary>
    public class SvgStroke : ISvgAttribute
    {
        public SvgStroke()
        {
        }

        public SvgStroke(SvgStroke svgstroke)
        {
            Color = svgstroke.Color;
            DashArray = svgstroke.DashArray;
            DashOffset = svgstroke.DashOffset;
            LineCap = svgstroke.LineCap;
            LineJoin = svgstroke.LineJoin;
            MiterLimit = svgstroke.MiterLimit;
            Opacity = svgstroke.Opacity;
            Width = svgstroke.Width;
        }

        /// <summary>
        /// Gets or sets the appearance of the Stroke. Can be color, pattern or gradient (e.g. url(#pattern)).
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the stroke dash array. To present stroke as a pattern of dashes and gaps, assign properly formatted string.
        /// </summary>
        public string DashArray { get; set; }

        /// <summary>
        /// Gets or sets the dash offset. To render offset, assign value to DashOffset property. However, this will only work if a DashArray is assigned.
        /// </summary>
        public SvgValue DashOffset { get; set; }

        /// <summary>
        /// Gets or sets the style of the stroke at the start and end of an open subpath.
        /// </summary>
        public StrokeLineCapStyle? LineCap { get; set; }

        /// <summary>
        /// Gets or sets the shape definition at the join point of two lines.
        /// </summary>
        public StrokeLineJoinStyle? LineJoin { get; set; }

        /// <summary>
        /// Gets or sets the miter limit. Must be greater then or equal to 1.
        /// </summary>
        public int? MiterLimit { get; set; }

        /// <summary>
        /// Gets or sets the opacity of the stroke.
        /// </summary>
        public SvgValue Opacity { get; set; }

        /// <summary>
        /// Gets or sets the width of the stroke.
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
