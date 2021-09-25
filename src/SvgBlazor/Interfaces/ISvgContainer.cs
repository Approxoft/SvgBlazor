using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer: ISvgElement
    {
        ISvgContainer Add(SvgElement element);
        ISvgContainer Remove(SvgElement element);
        void ElementMouseOver(SvgElement element, MouseEventArgs args);
        void ElementMouseOut(SvgElement element, MouseEventArgs args);
    }
}
