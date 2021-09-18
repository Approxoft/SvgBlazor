using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;

namespace SvgBlazor
{
    public class SvgElementBase : ComponentBase
    {
        [Parameter] public SvgValue Id { get; set; }

        [Parameter] public string Class { get; set; }

        [Parameter] public string Style { get; set; }

        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
