using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public partial class SvgCircle : SvgElementBase
    {
        /// <summary>
        /// The x-axis coordinate of the center of the circle.
        /// </summary>
        [Parameter] public SvgValue CenterX { get; set; }

        /// <summary>
        /// The y-axis coordinate of the center of the circle.
        /// </summary>
        [Parameter] public SvgValue CenterY { get; set; }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        [Parameter] public SvgValue Radius { get; set; }
    }
}
