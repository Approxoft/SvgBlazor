using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextShiftXYExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                Text = "That's a nice shift!",
                ShiftX = 20,
                ShiftY = 10,
            };
            /* #example-code-end */
            svg.Add(text);
        }
    }
}