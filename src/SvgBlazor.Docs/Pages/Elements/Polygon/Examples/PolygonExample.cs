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
            /* #example-code-start */
            var polygon = new SvgPolygon
            {
                Points = new List<PointF>
                {
                    new PointF(160, 200),
                    new PointF(40, 200),
                    new PointF(0, 80),
                    new PointF(100, 0),
                    new PointF(200, 80),
                },
                Fill = new SvgFill { Color = "#aabbcc" },
            };
            /* #example-code-end */

            svg.Add(polygon);
        }
    }
}
