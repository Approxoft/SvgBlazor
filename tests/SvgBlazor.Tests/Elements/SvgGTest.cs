using System;
using Xunit;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor.Tests
{
    public class SvgGTest : TestContext
    {
        [Fact]
        public void RendersSvgGWithChildContent()
        {
            var comp = RenderComponent<SvgG>(parameters => parameters
                .AddChildContent<ChildComponent>());

            Assert.StartsWith("<g", comp.Markup.Trim());
            Assert.Contains("<child", comp.Markup);
        }

        [Fact]
        public void RendersSvgGWithoutParameters()
        {
            var comp = RenderComponent<SvgG>();

            Assert.Equal("<g></g>", comp.Markup.Trim());
        }

        private class ChildComponent : ComponentBase
        {
            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                base.BuildRenderTree(builder);

                builder.OpenElement(0, "child");
                builder.CloseComponent();
            }
        }
    }
}