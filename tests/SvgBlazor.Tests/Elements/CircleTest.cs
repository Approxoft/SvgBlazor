using System.Drawing;
using Xunit;
using Bunit;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace SvgBlazor.Tests
{
    public class CircleTest : TestContextWithSvgBlazorJsModule
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
    }
}
