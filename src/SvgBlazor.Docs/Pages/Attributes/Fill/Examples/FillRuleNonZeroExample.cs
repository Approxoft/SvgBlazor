using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class FillRuleNonZeroExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var shape1 = new SvgPath
            {
                Path = "M 20 180 H 180 L 100 20 Z M 80 148 H 120 L 100 108 Z",
                Fill = new SvgFill { Rule = FillRule.NonZero },
                Stroke = new SvgStroke { Color = "grey" },
            };

            var shape2 = new SvgPath
            {
                Path = "M 220 180 H 380 L 300 20 z M 320 147 H 280 L 300 108 Z",
                Fill = new SvgFill { Rule = FillRule.NonZero },
                Stroke = new SvgStroke { Color = "grey" },
            };
            /* #example-code-end */

            svg.Add(shape1);
            svg.Add(shape2);
        }
    }
}