using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeDashArrayExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 75,
                Stroke = new SvgStroke
                {
                    Color = "green",
                    Width = 15,
                    DashArray = "1 2",
                },
            };
            svg.Add(circle);
        }
    }
}