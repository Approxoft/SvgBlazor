using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextLengthAdjustSpacingExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                Text = "I wish there was more space here...",
                LengthAdjust = TextLengthAdjust.Spacing,
                TextLength = 200,
            };
            /* #example-code-end */
            svg.Add(text);
        }
    }
}
