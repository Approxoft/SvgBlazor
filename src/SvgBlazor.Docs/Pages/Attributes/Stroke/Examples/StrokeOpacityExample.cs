using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeOpacityExample : IExampleCode
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
                    Color = "yellow",
                    Width = new SvgValue(15),
                    Opacity = 0.5f,
                },
            };
            svg.Add(circle);
        }
    }
}