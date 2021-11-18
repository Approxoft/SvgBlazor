using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class CircleExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 20,
                Fill = new SvgFill { Color = "#27ba0d" },
            };
            /* #example-code-end */

            svg.Add(circle);
        }
    }
}
