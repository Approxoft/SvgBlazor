using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineCapRoundExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var lineCapRound = new SvgStroke
            {
                Color = "black",
                Width = 30,
                LineCap = StrokeLineCapStyle.Round,
            };

            var line = new SvgLine
            {
                X1 = 15,
                Y1 = 20,
                X2 = 185,
                Y2 = 20,
                Stroke = lineCapRound,
            };

            var highlight = new SvgPath
            {
                Path = "M15, 20h 170",
                Stroke = new SvgStroke
                {
                    Color = "gold",
                    Width = 1,
                },
            };
            /* #example-code-end */

            svg.Add(line);
            svg.Add(highlight);
        }
    }
}
