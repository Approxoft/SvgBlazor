// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Xunit;
using Bunit;

namespace SvgBlazor.Tests
{
    public class RectTest : TestContextWithSvgBlazorJsModule
    {
        [Fact]
        public void RendersSvgRectWithParameters()
        {
            var comp = RenderComponent<SvgComponent>();

            comp.InvokeAsync(() => comp.Instance.Add(new SvgRect()
            {
                X = 1,
                Y = 2,
                Width = 3,
                Height = 4,
                Rx = 5,
                Ry = 6,
            }));

            comp.Render();

            var element = comp.Find("rect");
            Assert.Contains("1", element.GetAttribute("x"));
            Assert.Contains("2", element.GetAttribute("y"));
            Assert.Contains("3", element.GetAttribute("width"));
            Assert.Contains("4", element.GetAttribute("height"));
            Assert.Contains("5", element.GetAttribute("rx"));
            Assert.Contains("6", element.GetAttribute("ry"));
        }

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgRect()
            {
                X = 1f,
                Y = 2f,
                Width = 3f,
                Height = 4f,
                Rx = 5f,
                Ry = 6f,
            };

            var e2 = new SvgRect(e1);

            Assert.Equal(1f, e2.X.ToFloat());
            Assert.Equal(2f, e2.Y.ToFloat());
            Assert.Equal(3f, e2.Width.ToFloat());
            Assert.Equal(4f, e2.Height.ToFloat());
            Assert.Equal(5f, e2.Rx.ToFloat());
            Assert.Equal(6f, e2.Ry.ToFloat());
        }
    }
}