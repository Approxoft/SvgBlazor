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
    public class SvgG : SvgContainer, ISvgFillable
    {
        /// <summary>
        /// The fill color of the group.
        /// </summary>
        public SvgFill Fill { get; set; } = new SvgFill();

        public override string Tag() => "g";

        public override RectangleF BoundingRect() => throw new NotImplementedException();

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            Fill.RenderAttributes(builder);
        }
    }
}
