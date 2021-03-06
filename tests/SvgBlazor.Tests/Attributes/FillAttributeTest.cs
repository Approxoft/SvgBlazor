// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgFill()
            {
                Color = "green",
                Opacity = 0.5f,
                Rule = FillRule.EvenOdd,
            };

            var e2 = new SvgFill(e1);

            Assert.Equal("green", e2.Color);
            Assert.Equal(0.5f, e2.Opacity.ToFloat());
            Assert.Equal(FillRule.EvenOdd, e2.Rule);
        }

        private class DummyFillAttributesElement : SvgElement
        {
            public override string Tag() => "elementwithfill";
        }
    }
}
