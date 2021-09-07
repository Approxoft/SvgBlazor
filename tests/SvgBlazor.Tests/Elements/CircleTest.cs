using System;
using Xunit;
using SvgBlazor.Elements;
using Bunit;

namespace SvgBlazor.Tests
{
    public class CircleTest : TestContext
    {
        [Fact]
        public void RendersSvgCircle_GivenSvgBlazorCircle()
        {
            var comp = RenderComponent<SvgCircle>(parameters => parameters
                .Add(p => p.CenterX, 1)
                .Add(p => p.CenterY, 2)
                .Add(p => p.Radius, 3)
            );

            Assert.StartsWith("<circle", comp.Markup.Trim());
            Assert.Contains("cx=\"1\"", comp.Markup);
            Assert.Contains("cy=\"2\"", comp.Markup);
            Assert.Contains("r=\"3\"", comp.Markup);
        }

        [Fact]
        public void RendersSvgCircleWithoutParameters_GivenSvgBlazorCircleWithoutParameters()
        {
            var comp = RenderComponent<SvgCircle>();

            Assert.Equal("<circle></circle>", comp.Markup.Trim());
        }
    }
}
