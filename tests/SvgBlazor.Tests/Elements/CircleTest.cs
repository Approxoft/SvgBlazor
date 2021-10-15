using System.Drawing;
using Xunit;
using Bunit;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace SvgBlazor.Tests
{
    public class CircleTest : TestContext
    {
        [Fact]
        public void RendersSvgCircleWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgCircle {
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

        [Fact]
        public void SvgCircleBoundingBox()
        {
            var element = new SvgCircle {
                CenterX = 1,
                CenterY = 2,
                Radius = 3,
            };

            var brect = element.BoundingRect();
            Assert.Equal(new RectangleF(-2, -1, 6, 6), brect);
        }

        [Fact]
        public async void SvgCircleBoundingBox2()
        {
            JSInterop
                .SetupModule("./SvgBlazor.js")
                .Setup<RectangleF>("BBox", _ => true)
                .SetResult(new RectangleF
                {
                    X = 0,
                    Y = 0,
                    Width = 6,
                    Height = 6,
                });

            var comp = RenderComponent<SvgComponent>();
            var circle = new SvgCircle
            {
                CenterX = 1,
                CenterY = 2,
                Radius = 3,
            };

            await comp.InvokeAsync(() => comp.Instance.Add(circle));
            comp.Render();

            var brect = await circle.GetBoundingBox();

            Assert.Equal(new RectangleF(0, 0, 6, 6), brect);
        }
    }
}
