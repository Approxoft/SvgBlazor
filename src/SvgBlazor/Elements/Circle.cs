using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Elements
{
    public class Circle : ComponentBase
    {
        [Parameter]
        public double Radius { get; set; }

        [Parameter]
        public double CenterX { get; set; }

        [Parameter]
        public double CenterY { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "circle");
            builder.AddAttribute(1, "cx", CenterX);
            builder.AddAttribute(2, "cy", CenterY);
            builder.AddAttribute(2, "r", Radius);
            builder.CloseComponent();
        }
    }
}
