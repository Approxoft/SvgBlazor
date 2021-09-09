using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public abstract class SvgElement: ComponentBase
    {
        [Parameter] public SvgValue Id { get; set; }

        [Parameter] public string Class { get; set; }

        [Parameter] public string Style { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, Tag());
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", Class);
            builder.AddAttribute(3, "style", Style);

            AddAttributes(builder);

            builder.CloseElement();
        }

        protected virtual void AddAttributes(RenderTreeBuilder builder)
        {
        }

        protected abstract string Tag();
    }
}
