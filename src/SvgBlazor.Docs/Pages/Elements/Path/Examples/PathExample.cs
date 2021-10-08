using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class PathExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            var line = new SvgPath()
            {
                Path = "M 10, 30 " +
                "A 20, 20 0, 0, 1 50, 30 " +
                "A 20, 20 0, 0, 1 90, 30 " +
                "Q 90, 60 50, 90 " +
                "Q 10, 60 10, 30 z",
                Fill = new SvgFill { Color = "pink" },
                Stroke = new SvgStroke { Color = "red" },
            };
            svg.Add(line);
        }
    }
}
