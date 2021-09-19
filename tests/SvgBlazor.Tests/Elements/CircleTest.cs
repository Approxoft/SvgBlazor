using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class CircleTest : TestContext
    {
        [Fact]
        public void RendersSvgCircleWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgCircle() {
                CenterX = 1,
                CenterY = 2,
                Radius = 3,
            }));

            comp.Render();

            var element = comp.Find("circle");
            Assert.Contains("1", element.GetAttribute("cx"));
            Assert.Contains("2", element.GetAttribute("cy"));
            Assert.Contains("3", element.GetAttribute("r"));
        }
    }
}
