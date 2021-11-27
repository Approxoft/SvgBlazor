using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextLengthAdjustSpacingExample : TextBasicExample
    {
        public override void Example(SvgComponent svg)
        {
            base.Example(svg);
            /* #example-code-start */
            Text.LengthAdjust = TextLengthAdjust.Spacing;
            Text.TextLength = 100;
            /* #example-code-end */
            svg.Add(Text);
        }
    }
}