using System;
using System.Drawing;
using Xunit;
using Bunit;
using System.Collections.Generic;

namespace SvgBlazor.Tests
{
    public class SvgPolygonTest : TestContext
    {
        [Fact]
        public void RendersSvgPolygonWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            var polygon = new SvgPolygon();
            polygon.AddPoint(new PointF(0, 0));
            polygon.AddPoint(new PointF(200, 200));

            comp.InvokeAsync(() => comp.Instance.Add(polygon));

            comp.Render();

            var element = comp.Find("polygon");
            Assert.Equal("0 0 200 200", element.GetAttribute("points"));
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
        public void SvgPolygonBoundingBox()
        {
            var element = new SvgPolygon();
            element.AddPoint(new PointF(25, 10));
            element.AddPoint(new PointF(50, 20));
            element.AddPoint(new PointF(100, 40));
            element.AddPoint(new PointF(200, 80));

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(25, 10, 175, 70), brect);
        }

        [Fact]
        public void SvgPolygonBoundingBoxWhenSettingPoints()
        {
            var element = new SvgPolygon
            {
                Points = new List<PointF>
                {
                    new PointF(25, 10),
                    new PointF(50, 20),
                    new PointF(100, 40),
                    new PointF(200, 80),
                }
            };

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(25, 10, 175, 70), brect);
        }

        [Fact]
        public void SvgPolygonBoundingBoxWhenPointsChanged()
        {
            var element = new SvgPolygon
            {
                Points = new List<PointF>
                {
                    new PointF(2000, 10),
                }
            };

            element.Points = new List<PointF>
            {
                new PointF(25, 10),
                new PointF(50, 20),
                new PointF(100, 40),
                new PointF(200, 80),
            };

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(25, 10, 175, 70), brect);
        }
    }
}
