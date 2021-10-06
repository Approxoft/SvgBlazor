using System;
using SvgBlazor.Interfaces;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Base
{
    public class SvgFillable: ISvgFillable
    {
        public virtual SvgFill Fill { get; set; }
    }
}
