using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Elements
{
    public class Rect : ComponentBase
    {
        [Parameter]
        public double? X { get; set; }

        [Parameter]
        public double? Y { get; set; }

        [Parameter]
        public double Width { get; set; }

        [Parameter]
        public double Height { get; set; }

        [Parameter]
        public double? RX { get; set; }

        [Parameter]
        public double? RY { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "rect");

            if (X.HasValue)
                builder.AddAttribute(0, "x", X);

            if (Y.HasValue)
                builder.AddAttribute(0, "y", Y);

            builder.AddAttribute(0, "width", Width);
            builder.AddAttribute(0, "height", Height);

            if (RX.HasValue)
                builder.AddAttribute(0, "rx", RX);

            if (RY.HasValue)
                builder.AddAttribute(0, "ry", RY);

            builder.CloseComponent();
        }
    }
}
