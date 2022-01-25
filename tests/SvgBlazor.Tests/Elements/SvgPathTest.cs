// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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

        [Fact]
        public void CopyConstructor()
        {
            var e1 = new SvgPath()
            {
                Path = "M10 10",
            };

            var e2 = new SvgPath(e1);

            Assert.Equal("M10 10", e2.Path);
        }
    }
}