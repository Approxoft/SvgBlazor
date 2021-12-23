using System;
using System.Drawing;
using Xunit;
using Bunit;
using System.Collections.Generic;

namespace SvgBlazor.Tests
{
    public class SvgPolygonTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersSvgPolygonWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            var polygon = new SvgPolygon();
            polygon.AddPoint(new PointF(0, 0.1f));
            polygon.AddPoint(new PointF(200, 200.01f));

            comp.InvokeAsync(() => comp.Instance.Add(polygon));

            comp.Render();

            var element = comp.Find("polygon");
            Assert.Equal("0 0.1 200 200.01", element.GetAttribute("points"));
        }

        [Fact]
        public void RendersSvgPolygonWithSetPoints()
        {
            var comp = RenderComponent<SvgComponent>();

            var polygon = new SvgPolygon
            {
                Points = new List<PointF>
                {
                    new PointF(0, 0),
                    new PointF(200, 200),
                },
            };

            comp.InvokeAsync(() => comp.Instance.Add(polygon));
            comp.Render();

            var element = comp.Find("polygon");
            Assert.Equal("0 0 200 200", element.GetAttribute("points"));
        }

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgPolygon()
            {
                Points = new List<PointF>
                {
                    new PointF(0, 0),
                    new PointF(200, 200),
                },
            };

            var e2 = new SvgPolygon(e1);

            Assert.Equal(e1.Points, e2.Points);
        }
    }
}
