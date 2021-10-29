using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeDashOffsetExample : IExampleCode
    {
        private SvgValue _dashOffset;

        public StrokeDashOffsetExample(SvgValue dashOffset) => _dashOffset = dashOffset;

        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var referenceLine = new SvgLine
            {
                X1 = 20,
                Y1 = 5,
                X2 = 175,
                Y2 = 5,
                Stroke = new SvgStroke
                {
                    Color = "red",
                    Width = 10,
                    DashArray = "50",
                },
            };

            var line = new SvgLine
            {
                X1 = 20,
                Y1 = 20,
                X2 = 175,
                Y2 = 20,
                Stroke = new SvgStroke
                {
                    Color = "blue",
                    Width = 10,
                    DashArray = "50",
                    DashOffset = _dashOffset,
                },
            };
            /* #example-code-end */

            svg.Add(referenceLine);
            svg.Add(line);
        }
    }
}