using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var text = new SvgText()
            {
                X = 10,
                Y = 20,
                Text = "This is just awesome!",
            };
            svg.Add(text);
        }
    }
}
