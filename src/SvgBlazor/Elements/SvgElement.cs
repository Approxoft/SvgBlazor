using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace SvgBlazor
{
    public class SvgElement: SvgElementBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, SvgTag);
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", Class);
            builder.AddAttribute(3, "style", Style);

            foreach (var attribute in Attributes)
            {
                builder.AddAttribute(10, attribute.Key, attribute.Value);
            }
            builder.CloseComponent();
        }

        protected void addAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(1, "id", Id);
        }
    }
}
