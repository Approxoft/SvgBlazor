using Microsoft.AspNetCore.Components.Rendering;
using SvgBlazor.Extensions;

namespace SvgBlazor
{
    public class SvgFill
    {
        public string Color { get; set; }

        public SvgValue Opacity { get; set; }

        public FillRule? Rule { get; set; }

        public void RenderAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "fill", Color);
            builder.AddAttribute(1, "fill-opacity", Opacity);
            builder.AddAttribute(2, "fill-rule", Rule?.ToStringValue());
        }
    }
}