using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public class SvgStroke
    {
        // string like e.g. colors, patterns (e.g. url(#pattern)) or gradients
        // TODO: should this be string only? Discuss
        string Stroke { get; set; }

        // The stroke-dasharray property can accept any length, including unitless values (e.g. 2, 2.5, 2em, 15%).
        // More than one value is also acceptable (e.g. 2, 2, 3)
        // TODO: should this be a separate value type? Or SvgValue can be used here? Discuss
        string StrokeDashArray { get; set; }

        /// <summary>
        /// // The dash offset. Acccepts single value percentage or length based
        /// </summary>
        SvgValue StrokeDashOffset { get; set; }

        /// <summary>
        /// Sets the style of the stroke at the start and end of an open subpath
        /// </summary>
        StrokeLineCapStyle? StrokeLineCap { get; set; }

        /// <summary>
        /// Sets the appearance at the join point of two lines
        /// </summary>
        StrokeLineJoinStyle? StrokeLineJoin { get; set; }

        /// <summary>
        /// Sets the miter limit. Must be greater then or equal to 1.
        /// </summary>
        int? StrokeMiterLimit { get; set; }

        /// <summary>
        /// Sets the opacity of the stroke.
        /// </summary>
        //TODO: Accepts [0 - 1] or percentage. Discuss
        float? StrokeOpacity { get; set; }

        /// <summary>
        /// Sets the width of the stroke.
        /// </summary>
        //TODO: Accepts <length> | <percentage>. Discuss
        string StrokeWidth { get; set; }

        public void RenderAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "stroke", Stroke);
            builder.AddAttribute(1, "stroke-dasharray", StrokeDashArray);
            builder.AddAttribute(2, "stroke-dashoffset", StrokeDashOffset);
            builder.AddAttribute(3, "stroke-linecap", StrokeLineCap);
            builder.AddAttribute(4, "stroke-linejoin", StrokeLineJoin);
            builder.AddAttribute(5, "stroke-miterlimit", StrokeMiterLimit);
            builder.AddAttribute(6, "stroke-opacity", StrokeOpacity);
            builder.AddAttribute(7, "stroke-width", StrokeWidth);

        }
    }
}
