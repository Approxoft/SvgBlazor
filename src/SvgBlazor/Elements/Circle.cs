using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Elements
{
    /// <summary>
    /// SVG circle element.
    /// </summary>
    public class Circle : ComponentBase
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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "circle");
            builder.AddAttribute(1, "cx", CenterX);
            builder.AddAttribute(2, "cy", CenterY);
            builder.AddAttribute(3, "r", Radius);
            builder.CloseComponent();
        }
    }
}
