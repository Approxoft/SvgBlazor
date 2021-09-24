using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Interfaces
{
    public interface ISvgElement
    {
        string Tag();
        void BuildElement(RenderTreeBuilder builder);
        void AddAttributes(RenderTreeBuilder builder);
        void SetParent(ISvgContainer parent);
        ISvgContainer Parent();
        void Refresh();
    }
}
