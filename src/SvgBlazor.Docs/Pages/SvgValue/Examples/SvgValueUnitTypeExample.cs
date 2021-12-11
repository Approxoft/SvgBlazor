using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class SvgValueUnitTypeExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var rectPercentage = new SvgRect
            {
                X = 0,
                Y = 0,
                Height = 50,
                Width = new SvgValue(50F, ValueUnit.Percentage),
                Fill = new SvgFill { Color = "blue" },
            };

            var rectPixels = new SvgRect
            {
                X = 0,
                Y = 100,
                Height = 50,
                Width = new SvgValue(50F, ValueUnit.Px),
                Fill = new SvgFill { Color = "red" },
            };
            /* #example-code-end */

            svg.Add(rectPercentage);
            svg.Add(rectPixels);
        }
    }
}
