using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class RectExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var rect = new SvgRect()
            {
                X = 10,
                Y = 20,
                Width = 180,
                Height = 180
            };
            svg.Add(rect);
        }
    }
}
