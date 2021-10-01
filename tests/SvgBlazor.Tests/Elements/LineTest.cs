using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class LineTest : TestContext
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
        public void SvgLineBoundingBoxStartPointSmallerThanEndPoint()
        {
            var line = new SvgLine()
            {
                X1 = 1,
                Y1 = 1,
                X2 = 5,
                Y2 = 5,
            };

            var rect = line.BoundingRect();
            Assert.Equal(new RectangleF(1, 1, 4, 4), rect);
        }

        public void SvgLineBoundingBoxStartPointLargerThanEndPoint()
        {
            var element = new SvgLine
            {
                X1 = 5,
                Y1 = 5,
                X2 = 1,
                Y2 = 1,
            };

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(1, 1, 4, 4), brect);
        }
    }
}
