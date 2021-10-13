using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SvgBlazor.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static async Task<RectangleF> GetBBox(this IJSRuntime jSRuntime, ElementReference elementReference)
        {
            var module = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./SvgBlazor.js");
            return await module.InvokeAsync<RectangleF>("BBox", elementReference);
        }
    }
}
