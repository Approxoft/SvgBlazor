using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextRotateExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                Text = "Whoa! Nice rotation!",
                Rotate = "20 0 20",
            };
            /* #example-code-end */
            svg.Add(text);
        }
    }
}