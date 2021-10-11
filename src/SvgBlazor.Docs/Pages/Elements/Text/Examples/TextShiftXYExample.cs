using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextShiftXYExample : TextBasicExample
    {
        private SvgValue _shiftX;
        private SvgValue _shiftY;

        public TextShiftXYExample(SvgValue shiftX, SvgValue shiftY)
        {
            _shiftX = shiftX;
            _shiftY = shiftY;
        }

        public override void Example(SvgComponent svg)
        {
            base.Example(svg);

            text.ShiftX = _shiftX;
            text.ShiftY = _shiftY;

            svg.Add(text);
        }
    }
}