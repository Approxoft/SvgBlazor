using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgG class is responsible for providing the SVG group element.
    /// </summary>
    public partial class SvgG : SvgContainer
    {
        public SvgG()
        {
        }

        public SvgG(SvgG svgg)
            : base(svgg)
        {
        }

        public override string Tag() => "g";
    }
}
