using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextDxDyExample : TextBasicExample
    {
        private SvgValue _dx;
        private SvgValue _dy;

        public TextDxDyExample(SvgValue dx, SvgValue dy)
        {
            _dx = dx;
            _dy = dy;
        }

        public override void Example(SvgComponent svg)
        {
            base.Example(svg);

            text.DX = _dx;
            text.DY = _dy;

            svg.Add(text);
        }
    }
}