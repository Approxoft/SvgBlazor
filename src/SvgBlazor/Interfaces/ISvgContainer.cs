using System;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer
    {
        ISvgContainer Add(SvgElement element);
        ISvgContainer Remove(SvgElement element);
        void Refresh();
        void ElementMouseOver(SvgElement element, MouseEventArgs args);
        void ElementMouseOut(SvgElement element, MouseEventArgs args);
    }
}
