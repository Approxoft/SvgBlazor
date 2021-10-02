using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer: ISvgElement
    {
        List<ISvgElement> Elements { get; set; }

        ISvgContainer Add(ISvgElement element);

        ISvgContainer Remove(ISvgElement element);

        void UpdateLayout();
    }
}
