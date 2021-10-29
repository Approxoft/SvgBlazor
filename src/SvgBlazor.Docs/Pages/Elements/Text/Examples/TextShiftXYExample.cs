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
            /* #example-code-start */
            base.Example(svg);

            Text.ShiftX = _shiftX;
            Text.ShiftY = _shiftY;
            /* #example-code-end */
        }
    }
}