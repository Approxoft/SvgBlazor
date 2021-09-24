﻿using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor.Interfaces
{
    public interface ISvgContainer
    {
        ISvgContainer Add(SvgElement element);
        ISvgContainer Remove(SvgElement element);
        void BuildElement(RenderTreeBuilder builder);
        void AddElements(RenderTreeBuilder builder);
        void Refresh();
        void ElementMouseOver(SvgElement element, MouseEventArgs args);
        void ElementMouseOut(SvgElement element, MouseEventArgs args);
    }
}
