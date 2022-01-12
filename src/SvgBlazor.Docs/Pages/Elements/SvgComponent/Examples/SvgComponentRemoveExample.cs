using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class SvgComponentRemoveExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var text = new SvgText
            {
                X = 35,
                Y = 50,
                Text = "Click me to remove",
                Stroke = new SvgStroke { Color = "red", },
            };

            text.OnClick = EventCallback.Factory.Create<MouseEventArgs>(text, (args) =>
            {
                svg.Remove(text);
            });

            svg.Add(text);
            /* #example-code-end */
        }
    }
}