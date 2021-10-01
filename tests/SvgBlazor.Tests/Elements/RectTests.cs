using System;
using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class RectTest : TestContext
    {
        [Fact]
        public void RendersSvgRectWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgRect()
            {
                X = 1,
                Y = 2,
                Width = 3,
                Height = 4,
                Rx = 5,
                Ry = 6
            }));

            comp.Render();

            var element = comp.Find("rect");
            Assert.Contains("1", element.GetAttribute("x"));
            Assert.Contains("2", element.GetAttribute("y"));
            Assert.Contains("3", element.GetAttribute("width"));
            Assert.Contains("4", element.GetAttribute("height"));
            Assert.Contains("5", element.GetAttribute("rx"));
            Assert.Contains("6", element.GetAttribute("ry"));
        }

        [Fact]
        public void SvgEllipseBoundingBox()
        {
            var element = new SvgRect() {
                X = 1,
                Y = 2,
                Width = 3,
                Height = 4
            };

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(1, 2, 3, 4), brect);
        }
    }
}