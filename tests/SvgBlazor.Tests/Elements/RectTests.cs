using System;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class RectTest : TestContext
    {
        [Fact]
        public void RendersSvgRectWithParameters()
        {
            var comp = RenderComponent<SvgRect>(parameters => parameters
                .Add(p => p.X, 1)
                .Add(p => p.Y, 2)
                .Add(p => p.Width, 3)
                .Add(p => p.Height, 4)
                .Add(p => p.Rx, 5)
                .Add(p => p.Ry, 6)
            );

            Assert.StartsWith("<rect", comp.Markup.Trim());
            Assert.Contains("x=\"1\"", comp.Markup);
            Assert.Contains("y=\"2\"", comp.Markup);
            Assert.Contains("width=\"3\"", comp.Markup);
            Assert.Contains("height=\"4\"", comp.Markup);
            Assert.Contains("rx=\"5\"", comp.Markup);
            Assert.Contains("ry=\"6\"", comp.Markup);
        }

        [Fact]
        public void RendersSvgRectWithoutParameters()
        {
            var comp = RenderComponent<SvgRect>();

            Assert.Equal("<rect></rect>", comp.Markup.Trim());
        }
    }
}