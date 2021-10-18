using System;
using System.Drawing;
using Bunit;
using Xunit;

namespace SvgBlazor.Tests.Components
{
    public class SvgComponentTests : SvgBlazorJsModuleTestContext
    {
        [Fact]
        public async void CalculatesBoudingBox()
        {
            var comp = RenderComponent<SvgComponent>();
            var circle = new SvgCircle
            {
                CenterX = 1,
                CenterY = 2,
                Radius = 3,
            };

            await comp.InvokeAsync(() => comp.Instance.Add(circle));

            comp.Render();

            var bbox = await comp.Instance.GetBoundingBox(circle);
            Assert.Equal(new RectangleF(0, 0, 10, 10), bbox);
        }
    }
}
