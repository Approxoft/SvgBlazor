using System;
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

            comp.InvokeAsync(() => comp.Instance.Add(new SvgPolygon()
            {
                Points = "0 0 200 200",
            }));

            comp.Render();

            var element = comp.Find("polygon");
            Assert.Contains("0 0 200 200", element.GetAttribute("points"));
        }
    }
}
