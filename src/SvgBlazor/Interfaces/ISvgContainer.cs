using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer
    {
        ISvgContainer Add(ISvgElement element);
        ISvgContainer Remove(ISvgElement element);
    }
}
