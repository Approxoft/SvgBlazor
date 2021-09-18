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
            var comp = RenderComponent<SvgPolygon>(parameters => parameters
                .Add(p => p.Points, "0 0 200 200")
            );

            Assert.StartsWith("<polygon", comp.Markup.Trim());
            Assert.Contains("points=\"0 0 200 200\"", comp.Markup);
        }

        [Fact]
        public void RendersSvgPolygonWithoutParameters()
        {
            var comp = RenderComponent<SvgPolygon>();

            Assert.Equal("<polygon></polygon>", comp.Markup.Trim());
        }
    }
}