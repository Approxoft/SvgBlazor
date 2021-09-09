using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    // TODO: implement the rest of attributes: https://developer.mozilla.org/en-US/docs/Web/SVG/Element/text
    public class SvgText : ComponentBase
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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddContent(3, ChildContent);
            builder.CloseComponent();
        }
    }
}
