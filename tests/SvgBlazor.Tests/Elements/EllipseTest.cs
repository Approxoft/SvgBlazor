using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class EllipseTest : SvgBlazorJsModuleTestContext
    {
        [Fact]
        public void RendersSvgEllipseWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgEllipse() {
                CenterX = 1,
                CenterY = 2,
                RadiusX = 3,
                RadiusY = 4,
            }));

            comp.Render();

            var element = comp.Find("ellipse");
            Assert.Contains("1", element.GetAttribute("cx"));
            Assert.Contains("2", element.GetAttribute("cy"));
            Assert.Contains("3", element.GetAttribute("rx"));
            Assert.Contains("4", element.GetAttribute("ry"));
        }
    }
}
