using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextBasicExample : IExampleCode
    {
        /* #example-code-start */
        private SvgText _text = new SvgText
        {
            X = 10,
            Y = 20,
            Text = "This is just awesome!",
            Fill = new SvgFill { Color = "black" },
        };
        /* #example-code-end */

        public SvgText Text
        {
            get => _text;
        }

        public virtual void Example(SvgComponent svg)
        {
            svg.Add(_text);
        }
    }
}
