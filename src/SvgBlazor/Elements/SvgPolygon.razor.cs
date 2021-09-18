using System;
using Microsoft.AspNetCore.Components;

namespace SvgBlazor
{
    /// <summary>
    /// SVG polygon element.
    /// </summary>
    public partial class SvgPolygon : SvgElementBase
    {
        /// <summary>
        /// The list of points (pairs of x,y absolute coordinates) required to draw the polygon.
        /// </summary>
        [Parameter] public string Points { get; set; }

        /// <summary>
        /// The color used to paint the outline of the shape.
        /// </summary>
        [Parameter] public string Stroke { get; set; }
    }
}
