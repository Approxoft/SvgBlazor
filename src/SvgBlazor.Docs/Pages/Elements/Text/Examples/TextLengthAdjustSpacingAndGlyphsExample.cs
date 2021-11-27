using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextLengthAdjustSpacingAndGlyphsExample : TextBasicExample
    {
        public override void Example(SvgComponent svg)
        {
            base.Example(svg);
            /* #example-code-start */
            Text.LengthAdjust = TextLengthAdjust.SpacingAndGlyphs;
            Text.TextLength = 100;
            /* #example-code-end */
            svg.Add(Text);
        }
    }
}
