using System;
using Bunit;
using Xunit;

namespace SvgBlazor.Tests.Elements
{
    public class SvgPathTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersAttributes()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgPath
            {
                Path = "M10 10",
            }));

            comp.Render();

            var element = comp.Find("path");
            Assert.Contains("M10 10", element.GetAttribute("d"));
        }
    }
}