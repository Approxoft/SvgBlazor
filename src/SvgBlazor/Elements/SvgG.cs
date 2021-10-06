using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// Svg G element
    /// </summary>
    public class SvgG : SvgContainer
    {
        public override string Tag() => "g";

        public override RectangleF BoundingRect() => throw new NotImplementedException();
    }
}
