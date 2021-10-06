using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Interfaces
{
    public interface ISvgFillable
    {
        public string Fill { get; set; }

        public void AddAttributes(RenderTreeBuilder builder);
    }
}
