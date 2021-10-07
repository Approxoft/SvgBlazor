using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeDashOffsetExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var lineWithOffset50 = new SvgLine
            {
                X1 = 20,
                Y1 = 20,
                X2 = 175,
                Y2 = 20,
                Stroke = new SvgStroke
                {
                    Color = "blue",
                    Width = 15,
                    DashArray = "50",
                    DashOffset = 50,
                },
            };

            var lineWithOffset0 = new SvgLine
            {
                X1 = 20,
                Y1 = 50,
                X2 = 175,
                Y2 = 50,
                Stroke = new SvgStroke
                {
                    Color = "red",
                    Width = 15,
                    DashArray = "50",
                    DashOffset = 0,
                },
            };

            svg.Add(lineWithOffset50);
            svg.Add(lineWithOffset0);
        }
    }
}