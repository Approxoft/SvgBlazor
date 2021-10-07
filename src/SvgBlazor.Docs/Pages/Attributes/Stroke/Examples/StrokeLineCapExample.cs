using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineCapExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var buttLine = new SvgLine
            {
                X1 = 20,
                Y1 = 20,
                X2 = 175,
                Y2 = 20,
                Stroke = new SvgStroke
                {
                    Color = "blue",
                    Width = new SvgValue(15),
                    LineCap = StrokeLineCapStyle.Butt,
                },
            };

            var squareLine = new SvgLine
            {
                X1 = 20,
                Y1 = 50,
                X2 = 175,
                Y2 = 50,
                Stroke = new SvgStroke
                {
                    Color = "red",
                    Width = new SvgValue(15),
                    LineCap = StrokeLineCapStyle.Square,
                },
            };

            var roundLine = new SvgLine
            {
                X1 = 20,
                Y1 = 80,
                X2 = 175,
                Y2 = 80,
                Stroke = new SvgStroke
                {
                    Color = "green",
                    Width = 15,
                    LineCap = StrokeLineCapStyle.Round,
                },
            };

            svg.Add(buttLine);
            svg.Add(squareLine);
            svg.Add(roundLine);
        }
    }
}