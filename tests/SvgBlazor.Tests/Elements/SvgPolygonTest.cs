using System;
using System.Drawing;
using Xunit;
using Bunit;

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
            Assert.Contains("0 0 200 200", element.GetAttribute("points"));
        }
    }
}
