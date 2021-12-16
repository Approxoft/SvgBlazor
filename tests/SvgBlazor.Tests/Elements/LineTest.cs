using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class LineTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersSvgLineWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgLine()
            {
                X1 = 1,
                Y1 = 2,
                X2 = 3,
                Y2 = 4,
            }));

            comp.Render();

            var element = comp.Find("line");
            Assert.Contains("1", element.GetAttribute("x1"));
            Assert.Contains("2", element.GetAttribute("y1"));
            Assert.Contains("3", element.GetAttribute("x2"));
            Assert.Contains("4", element.GetAttribute("y2"));
        }

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgLine()
            {
                X1 = 1f,
                Y1 = 2f,
                X2 = 3f,
                Y2 = 4f,
            };

            var e2 = new SvgLine(e1);

            Assert.Equal(1f, e2.X1.ToFloat());
            Assert.Equal(2f, e2.Y1.ToFloat());
            Assert.Equal(3f, e2.X2.ToFloat());
            Assert.Equal(4f, e2.Y2.ToFloat());
        }
    }
}
