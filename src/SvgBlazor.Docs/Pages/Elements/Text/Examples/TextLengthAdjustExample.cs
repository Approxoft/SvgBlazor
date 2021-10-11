using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextLengthAdjustExample : TextBasicExample
    {
        private TextLengthAdjust _adjust;
        private SvgValue _textLength;

        public TextLengthAdjustExample(TextLengthAdjust adjust, SvgValue textLength)
        {
            _adjust = adjust;
            _textLength = textLength;
        }

        public override void Example(SvgComponent svg)
        {
            base.Example(svg);

            text.LengthAdjust = _adjust;
            text.TextLength = _textLength;

            svg.Add(text);
        }
    }
}