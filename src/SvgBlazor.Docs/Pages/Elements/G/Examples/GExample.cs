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

            group.Add(new SvgCircle
            {
                CenterX = 50,
                CenterY = 50,
                Radius = 50,
            });

            group.Add(new SvgCircle
            {
                CenterX = 150,
                CenterY = 150,
                Radius = 50,
            });
            /* #example-code-end */

            svg.Add(group);
        }
    }
}
