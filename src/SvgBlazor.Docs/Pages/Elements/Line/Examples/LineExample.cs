using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class LineExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var line = new SvgLine()
            {
                X1 = new Random().Next(0, 200),
                Y1 = new Random().Next(0, 200),
                X2 = new Random().Next(0, 200),
                Y2 = new Random().Next(0, 200),
                Stroke = new SvgStroke { Color = "red" },
            };
            /* #example-code-end */

            svg.Add(line);
        }
    }
}
