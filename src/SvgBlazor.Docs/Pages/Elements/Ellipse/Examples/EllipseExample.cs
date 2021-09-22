using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class EllipseExample: IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var ellipse = new SvgEllipse()
            {
                CenterX = 100,
                CenterY = 100,
                RadiusX = 40,
                RadiusY = 20
            };
            svg.Add(ellipse);
        }
    }
}
