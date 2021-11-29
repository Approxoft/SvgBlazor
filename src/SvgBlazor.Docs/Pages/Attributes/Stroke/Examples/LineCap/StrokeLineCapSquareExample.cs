using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineCapSquareExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var lineCapSquare = new SvgStroke
            {
                Color = "black",
                Width = 30,
                LineCap = StrokeLineCapStyle.Square,
            };

            var path = new SvgPath
            {
                Path = "M15, 20 h170",
                Stroke = new SvgStroke
                {
                    Color = "gold",
                    Width = 5,
                },
            };

            var line = new SvgLine
            {
                X1 = 15,
                Y1 = 20,
                X2 = 185,
                Y2 = 20,
                Stroke = lineCapSquare,
            };
            /* #example-code-end */

            svg.Add(line);
            svg.Add(path);
        }
    }
}