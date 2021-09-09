using System;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgGTest : TestContext
    {
        [Fact]
        public void RendersSvgGWithChildContent()
        {
            var child = RenderComponent<SvgCircle>(parameters => parameters
                .Add(p => p.CenterX, 1)
                .Add(p => p.CenterY, 2)
                .Add(p => p.Radius, 3));

            var comp = RenderComponent<SvgG>(parameters => parameters
                .AddChildContent<SvgCircle>(circleParameters => circleParameters
                    .Add(p => p.CenterX, "10")
                    .Add(p => p.CenterY, "20")
                    .Add(p => p.Radius, "3")));

            Assert.Equal("<g><circle cx=\"10\" cy=\"20\" r=\"3\"></circle></g>", comp.Markup.Trim());
        }

        [Fact]
        public void RendersSvgGWithoutParameters()
        {
            var comp = RenderComponent<SvgG>();

            Assert.Equal("<g></g>", comp.Markup.Trim());
        }
    }
}