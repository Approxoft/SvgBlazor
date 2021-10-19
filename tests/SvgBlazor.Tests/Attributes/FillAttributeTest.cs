using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;
using Bunit;
using SvgBlazor.Interfaces;

namespace SvgBlazor.Tests
{
    public class FillAttributeTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersAttributes()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new DummyFillAttributesElement {
                Fill = new SvgFill
                {
                    Color = "green",
                    Opacity = 0.5f,
                    Rule = FillRule.EvenOdd,
                },
            }));

            comp.Render();

            var element = comp.Find("elementwithfill");
            Assert.Contains("green", element.GetAttribute("fill"));
            Assert.Contains("0.5", element.GetAttribute("fill-opacity"));
            Assert.Contains("evenodd", element.GetAttribute("fill-rule"));
        }

        private class DummyFillAttributesElement : SvgElement
        {
            public override string Tag() => "elementwithfill";
        }
    }
}
