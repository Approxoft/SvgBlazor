using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// SVG rect element.
    /// </summary>
    public class SvgRect : ComponentBase
    {
        /// <summary>
        /// The x coordinate of the rect. Defaults to 0.
        /// </summary>
        [Parameter] public SvgValue X { get; set; }

        /// <summary>
        /// The y coordinate of the rect. Defaults to 0.
        /// </summary>
        [Parameter] public SvgValue Y { get; set; }

        /// <summary>
        /// The width of the rect.
        /// </summary>
        [Parameter] public SvgValue Width { get; set; }

        /// <summary>
        /// The height of the rect.
        /// </summary>
        [Parameter] public SvgValue Height { get; set; }

        /// <summary>
        /// The horizontal corner radius of the rect. Defaults to Ry (if specified).
        /// </summary>
        [Parameter] public SvgValue Rx { get; set; }

        /// <summary>
        /// The vertical corner radius of the rect. Defaults to Rx (if specified).
        /// </summary>
        [Parameter] public SvgValue Ry { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "rect");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "width", Width);
            builder.AddAttribute(4, "height", Height);
            builder.AddAttribute(5, "rx", Rx);
            builder.AddAttribute(6, "ry", Ry);
            builder.CloseComponent();
        }
    }
}
