using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgTextTest : TestContext
    {
        [Fact]
        public void RendersSvgTextWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgText()
            {
                X = 1,
                Y = 2,
                Text = "Test string"
            }));

            comp.Render();
            var element = comp.Find("text");
            Assert.Contains("1", element.GetAttribute("x"));
            Assert.Contains("2", element.GetAttribute("y"));
            Assert.Contains("Test string", element.TextContent);
        }
    }
}