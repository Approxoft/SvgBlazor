using System;
using System.Drawing;
using Bunit;

namespace SvgBlazor.Tests
{
    public class SvgBlazorJsModuleTestContext : TestContext
    {
        public SvgBlazorJsModuleTestContext()
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
