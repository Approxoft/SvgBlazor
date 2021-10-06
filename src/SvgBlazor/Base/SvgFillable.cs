using System;
using SvgBlazor.Interfaces;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Base
{
    public class SvgFillable: ISvgFillable
    {
        public virtual string Fill { get; set; }

        public virtual void AddAttributes(RenderTreeBuilder builder)
        {
            builder.AddAttribute(0, "fill", Fill);
        }
    }
}
