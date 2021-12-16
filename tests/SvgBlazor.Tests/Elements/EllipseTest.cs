using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class EllipseTest : TestContextWithSvgBlazorJsModule
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

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgEllipse()
            {
                CenterX = 1f,
                CenterY = 2f,
                RadiusX = 3f,
                RadiusY = 4f,
            };

            var e2 = new SvgEllipse(e1);

            Assert.Equal(1f, e2.CenterX.ToFloat());
            Assert.Equal(2f, e2.CenterY.ToFloat());
            Assert.Equal(3f, e2.RadiusX.ToFloat());
            Assert.Equal(4f, e2.RadiusY.ToFloat());
        }
    }
}
