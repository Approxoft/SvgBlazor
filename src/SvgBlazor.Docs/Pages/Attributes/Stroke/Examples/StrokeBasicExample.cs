using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeBasicExample : IExampleCode
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
                    Color = "pink",
                    Width = 15,
                },
            };
            svg.Add(circle);
        }
    }
}