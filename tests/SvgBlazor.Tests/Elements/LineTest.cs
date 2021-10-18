using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class LineTest : SvgBlazorJsModuleTestContext
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
    }
}
