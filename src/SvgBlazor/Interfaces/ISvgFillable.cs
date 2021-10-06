using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Interfaces
{
    public interface ISvgFillable
    {
        SvgFill Fill { get; set; }
    }
}
