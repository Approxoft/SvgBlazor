using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Interfaces
{
    public interface ISvgElement
    {
        string Tag();
        void BuildElement(RenderTreeBuilder builder);
        void AddElements(RenderTreeBuilder builder);
        void AddAttributes(RenderTreeBuilder builder);
    }
}
