﻿using System;
using System.Drawing;
using Xunit;
using Bunit;
using System.Collections.Generic;

namespace SvgBlazor.Tests
{
    public class SvgPolygonTest : SvgBlazorJsModuleTestContext
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
    }
}
