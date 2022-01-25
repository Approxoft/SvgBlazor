// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Bunit;

namespace SvgBlazor.Tests
{
    public class TestContextWithSvgBlazorJsModule : TestContext
    {
        public TestContextWithSvgBlazorJsModule()
        {
            SetupJSInterop();
        }

        private void SetupJSInterop()
        {
            JSInterop
                .SetupModule("./_content/SvgBlazor/SvgBlazor.js")
                .Setup<RectangleF>("BBox", _ => true)
                .SetResult(new RectangleF
                {
                    X = 0,
                    Y = 0,
                    Width = 10,
                    Height = 10,
                });
        }
    }
}
