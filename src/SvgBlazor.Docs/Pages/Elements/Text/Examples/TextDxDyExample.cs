using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextDxDyExample : IExampleCode
    {
        private SvgValue _dx;
        private SvgValue _dy;

        public TextDxDyExample(SvgValue dx, SvgValue dy)
        {
            _dx = dx;
            _dy = dy;
        }

        public void Example(SvgComponent svg)
        {
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                DX = _dx,
                DY = _dy,
                Text = "This is just awesome!",
                Fill = new SvgFill { Color = "red" },
            };
            svg.Add(text);
        }
    }
}