// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgComponentTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void SvgComponentOnClick()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnClick, _ => { eventHandled = true; })
            );

            comp.Render();

            var svg = comp.Find("svg");
            svg.Click();

            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseDown()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseDown, _ => { eventHandled = true; })
            );

            comp.Render();

            var svg = comp.Find("svg");
            svg.MouseDown();

            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseUp()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseUp, _ => { eventHandled = true; })
            );

            comp.Render();

            var svg = comp.Find("svg");
            svg.MouseUp();

            Assert.True(eventHandled);
        }

        [Fact]
        public void SvgComponentOnMouseMove()
        {
            bool eventHandled = false;

            var comp = RenderComponent<SvgComponent>(parameters => parameters
                .Add(p => p.OnMouseMove, _ => { eventHandled = true; })
            );

            comp.Render();

            var svg = comp.Find("svg");
            svg.MouseMove();

            Assert.True(eventHandled);
        }

        private class DummyElement : SvgElement
        {
            public override string Tag() => "dummy";
        }
    }
}
