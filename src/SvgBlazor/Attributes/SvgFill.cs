using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public class SvgFill
    {
        public string Fill { get; set; }

        public SvgValue Opacity { get; set; }

        public FillRule? Rule { get; set; }

        public void RenderAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "fill", Fill);
            builder.AddAttribute(1, "fill-opacity", Opacity);
            builder.AddAttribute(2, "fill-rule", Rule?.ToString().ToLower());
        }
    }
}