﻿using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineJoinArcsExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var d = "m28, 177 c46, -17 60, -77 30, -120c 50, 2 110, 35 114, 66";

            var path = new SvgPath
            {
                Path = d,
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 35,
                    LineJoin = StrokeLineJoinStyle.Arcs,
                },
                Fill = new SvgFill { Color = "none" },
            };

            var highlightPath = new SvgPath
            {
                Path = d,
                Stroke = new SvgStroke
                {
                    Color = "gold",
                    Width = 5,
                },
                Fill = new SvgFill { Color = "none" },
            };
            /* #example-code-end */
            svg.Add(path);
            svg.Add(highlightPath);
        }
    }
}