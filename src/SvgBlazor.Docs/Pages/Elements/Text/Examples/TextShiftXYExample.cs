using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextShiftXYExample : TextBasicExample
    {
        public override void Example(SvgComponent svg)
        {
            base.Example(svg);
            /* #example-code-start */
            Text.ShiftX = 20;
            Text.ShiftY = 10;
            /* #example-code-end */
        }
    }
}