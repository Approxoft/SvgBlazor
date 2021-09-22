using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class PolygonExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var polygon = new SvgPolygon()
            {
                Points = "0 0 50 50 100 50"
            };
            svg.Add(polygon);
        }
    }
}
