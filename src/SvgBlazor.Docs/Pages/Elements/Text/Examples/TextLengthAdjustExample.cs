using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextLengthAdjustExample : IExampleCode
    {
        private TextLengthAdjust _adjust;
        private SvgValue _textLength;

        public TextLengthAdjustExample(TextLengthAdjust adjust, SvgValue textLength)
        {
            _adjust = adjust;
            _textLength = textLength;
        }

        public void Example(SvgComponent svg)
        {
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                LengthAdjust = _adjust,
                TextLength = _textLength,
                Text = "This is just awesome!",
                Fill = new SvgFill { Color = "blue" },
            };

            svg.Add(text);
        }
    }
}