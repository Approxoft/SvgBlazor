using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextRotateExample : IExampleCode
    {
        private string _rotate;

        public TextRotateExample(string rotate) => _rotate = rotate;

        public void Example(SvgComponent svg)
        {
            var text = new SvgText
            {
                X = 10,
                Y = 20,
                Rotate = _rotate,
                Text = "This is just awesome!",
                Fill = new SvgFill { Color = "blue" },
            };
            svg.Add(text);
        }
    }
}