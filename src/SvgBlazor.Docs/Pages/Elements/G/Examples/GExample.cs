using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class GExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var group = new SvgG
            {
                Fill = new SvgFill { Color = "red" },
            };
            group.Add(new SvgCircle() { CenterX = "10", CenterY = "10", Radius = "10" });
            group.Add(new SvgCircle() { CenterX = "20", CenterY = "20", Radius = "5" });
            /* #example-code-end */

            svg.Add(group);
        }
    }
}
