using System;
using System.Collections.Generic;
using System.Drawing;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class PolygonExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var polygon = new SvgPolygon
            {
                Points = new List<PointF>
                {
                    new(0, 0),
                    new(50, 50),
                    new(100, 50)
                }
            };

            svg.Add(polygon);
        }
    }
}
