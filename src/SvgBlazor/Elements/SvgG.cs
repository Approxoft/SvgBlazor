using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// Svg G element
    /// </summary>
    public class SvgG : ComponentBase
    {
        /// <summary>
        /// The child content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "g");
            builder.AddContent(1, ChildContent);
            builder.CloseComponent();
        }
    }
}
