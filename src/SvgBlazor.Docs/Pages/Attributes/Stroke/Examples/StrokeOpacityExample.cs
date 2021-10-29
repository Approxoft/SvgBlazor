using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeOpacityExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 75,
                Stroke = new SvgStroke
                {
                    Color = "yellow",
                    Width = 15,
                    Opacity = 0.5f,
                },
            };
            /* #example-code-end */

            svg.Add(circle);
        }
    }
}