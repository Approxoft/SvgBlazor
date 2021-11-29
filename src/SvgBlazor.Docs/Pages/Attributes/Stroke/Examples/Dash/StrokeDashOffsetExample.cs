using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeDashOffsetExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var dashOffsetStroke = new SvgStroke
            {
                Color = "blue",
                Width = 10,
                DashArray = "50",
                DashOffset = 50,
            };
            /* #example-code-end */
            var line = new SvgLine
            {
                X1 = 20,
                Y1 = 20,
                X2 = 175,
                Y2 = 20,
                Stroke = dashOffsetStroke,
            };

            svg.Add(line);
        }
    }
}