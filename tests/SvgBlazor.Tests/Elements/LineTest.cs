using System;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class LineTest : TestContext
    {
        [Fact]
        public void RendersSvgCircleWithParameters()
        {
            var comp = RenderComponent<SvgLine>(parameters => parameters
                .Add(p => p.X1, 1)
                .Add(p => p.Y1, 2)
                .Add(p => p.X2, 3)
                .Add(p => p.Y2, 4)
            );

            Assert.StartsWith("<line", comp.Markup.Trim());
            Assert.Contains("x1=\"1\"", comp.Markup);
            Assert.Contains("y1=\"2\"", comp.Markup);
            Assert.Contains("x2=\"3\"", comp.Markup);
            Assert.Contains("y2=\"4\"", comp.Markup);
        }

        [Fact]
        public void RendersSvgCircleWithoutParameters()
        {
            var comp = RenderComponent<SvgLine>();

            Assert.Equal("<line></line>", comp.Markup.Trim());
        }
    }
}
