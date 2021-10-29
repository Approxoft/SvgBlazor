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
            /* #example-code-start */
            base.Example(svg);

            Text.Rotate = _rotate;
            /* #example-code-end */
        }
    }
}