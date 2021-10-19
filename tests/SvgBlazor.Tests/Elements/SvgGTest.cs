using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgGTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersSvgGWithChildContent()
        {
            var comp = RenderComponent<SvgComponent>();

            var group = new SvgG();
            group.Add(new ChildElement());
            comp.InvokeAsync(() => comp.Instance.Add(group));

            comp.Render();

            var element = comp.Find("g");
            Assert.Equal("tester", element.Children[0].TagName);
        }

        private class ChildElement : SvgElement
        {
            public override string Tag() => "tester";
        }
    }
}