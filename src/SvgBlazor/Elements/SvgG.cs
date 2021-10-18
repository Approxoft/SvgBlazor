using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// Svg G element
    /// </summary>
    public partial class SvgG : SvgContainer
    {
        public override string Tag() => "g";
    }
}
