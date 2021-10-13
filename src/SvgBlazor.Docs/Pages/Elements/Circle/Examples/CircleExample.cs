using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample: IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var circle = new SvgCircle()
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 20,
                Fill = new SvgFill { Color = "blue", Opacity = 0.5f },
            };

            circle.OnClick = EventCallback.Factory.Create<MouseEventArgs>(circle, async (args) =>
            {
                Console.WriteLine("Element clicked " + await circle.BoundingRect2());
            });

            svg.Add(circle);
        }
    }
}
