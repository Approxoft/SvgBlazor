using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public partial class SvgLine : SvgElementBase
    {
        /// <summary>
        /// Start point x-axis coordinate.
        /// </summary>
        [Parameter] public SvgValue X1 { get; set; }

        /// <summary>
        /// Start point y-axis coordinate.
        /// </summary>
        [Parameter] public SvgValue Y1 { get; set; }

        /// <summary>
        /// End point x-axis coordinate.
        /// </summary>
        [Parameter] public SvgValue X2 { get; set; }

        /// <summary>
        /// End point y-axis coordinate.
        /// </summary>
        [Parameter] public SvgValue Y2 { get; set; }

        /// <summary>
        /// The color used to paint the outline of the shape.
        /// </summary>
        [Parameter] public string Stroke { get; set; }
    }
}
