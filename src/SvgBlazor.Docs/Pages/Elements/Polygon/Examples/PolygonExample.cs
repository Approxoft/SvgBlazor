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
                    new PointF(0, 0),
                    new PointF(50, 50),
                    new PointF(100, 50),
                },
                Fill = new SvgFill { Color = "#aabbcc", Opacity = 0.5f },
            };

            svg.Add(polygon);
        }
    }
}
