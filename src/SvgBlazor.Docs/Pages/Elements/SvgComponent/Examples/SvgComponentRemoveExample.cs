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
                X = 25,
                Y = 25,
                Text = "Click to remove",
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