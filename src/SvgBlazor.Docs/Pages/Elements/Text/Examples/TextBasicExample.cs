using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextBasicExample : IExampleCode
    {
        protected SvgText text = new SvgText
        {
            X = 10,
            Y = 20,
            Text = "This is just awesome!",
            Fill = new SvgFill { Color = "black" },
        };

        public virtual void Example(SvgComponent svg)
        {
            svg.Add(text);
        }
    }
}
