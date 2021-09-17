using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public partial class SvgText : SvgElementBase
    {
        /// <summary>
        /// The x coordinate of the starting point of the text baseline.
        /// </summary>
        [Parameter] public SvgValue X { get; set; }

        /// <summary>
        /// The y coordinate of the starting point of the text baseline.
        /// </summary>
        [Parameter] public SvgValue Y { get; set; }

        /// <summary>
        /// The child content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
