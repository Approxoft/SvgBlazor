using System;
using System.Drawing;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class PolygonExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var polygon = new SvgPolygon();
            polygon.AddPoint(new PointF(0, 0));
            polygon.AddPoint(new PointF(50, 50));
            polygon.AddPoint(new PointF(100, 50));
            svg.Add(polygon);
        }
    }
}
