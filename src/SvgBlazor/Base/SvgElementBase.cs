using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace SvgBlazor
{
    public class SvgElementBase: ComponentBase
    {
        [Parameter] public string SvgTag { get; set; } = "svn";

        [Parameter] public SvgValue Id { get; set; }

        [Parameter] public string Class { get; set; }

        [Parameter] public string Style { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    }
}