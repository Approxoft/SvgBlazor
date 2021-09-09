using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgTextTest : TestContext
    {
        [Fact]
        public void RendersSvgTextWithParameters()
        {
            var comp = RenderComponent<SvgText>(parameters => parameters
                .Add(p => p.X, 1)
                .Add(p => p.Y, 2)
                .AddChildContent("Test string"));

            Assert.StartsWith("<text", comp.Markup.Trim());
            Assert.Contains("x=\"1\"", comp.Markup);
            Assert.Contains("y=\"2\"", comp.Markup);
            Assert.Contains("Test string", comp.Markup);
        }

        [Fact]
        public void RendersSvgTextWithoutParameters()
        {
            var comp = RenderComponent<SvgText>();

            Assert.Equal("<text></text>", comp.Markup.Trim());
        }
    }
}