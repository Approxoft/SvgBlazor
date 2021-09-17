using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// Svg G element
    /// </summary>
    public partial class SvgG : SvgElementBase
    {
        /// <summary>
        /// The child content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
