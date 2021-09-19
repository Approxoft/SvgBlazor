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

        List<SvgElementBase> elements = new List<SvgElementBase>();

        public void Add(SvgElementBase element)
        {
            elements.Add(element);
            StateHasChanged();
        }

        public void Remove(SvgElementBase element)
        {
            elements.Remove(element);
        }

        protected void BuildElements(RenderTreeBuilder builder)
        {
            foreach (var e in elements)
            {
                RenderFragment renderFragment = (builder) =>
                {
                    //builder.OpenComponent(0, e.GetType());
                    //builder.CloseComponent();
                    e.BuildRenderTree(builder);
                };
                builder.AddContent(6, renderFragment);
            }
        }

        public void OnClickHandler(MouseEventArgs arg)
        {
            Console.WriteLine("OnClickHandler");
            OnClick.InvokeAsync();
        }
    }
}
