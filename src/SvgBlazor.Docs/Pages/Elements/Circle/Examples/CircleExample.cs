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
                CenterX = 50,
                CenterY = 50,
                Radius = 50,
                Fill = new SvgFill { Color = "#27ba0d" },
            };
            /* #example-code-end */

            svg.Add(circle);
        }
    }
}
