using System;
using Bunit;
using Xunit;

namespace SvgBlazor.Tests.Elements
{
	public class SvgUseTest : TestContextWithSvgBlazorJsModule
    {
		[Fact]
		public void RendersSvgWithDuplicatedElement()
        {
            var comp = RenderComponent<SvgComponent>();
            
            comp.InvokeAsync(() => comp.Instance.Add(new SvgUse
            {
                X = 20,
                Y = 30,
                Element = new SvgCircle { Id = "circleId", CenterX = 10, CenterY = 10 },
                Fill = new SvgFill { Color = "blue" },
            }));

            var element = comp.Find("use");
            Assert.Contains("#circleId", element.GetAttribute("href"));
            Assert.Contains("20", element.GetAttribute("x"));
            Assert.Contains("30", element.GetAttribute("y"));
        }
	}
}