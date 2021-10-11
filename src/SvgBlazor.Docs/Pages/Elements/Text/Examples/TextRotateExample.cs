using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextRotateExample : TextBasicExample
    {
        private string _rotate;

        public TextRotateExample(string rotate) => _rotate = rotate;

        public override void Example(SvgComponent svg)
        {
            base.Example(svg);

            text.Rotate = _rotate;
        }
    }
}