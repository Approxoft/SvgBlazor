// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Bunit;
using Xunit;

namespace SvgBlazor.Tests.Components
{
    public class SvgComponentTests : TestContextWithSvgBlazorJsModule
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
