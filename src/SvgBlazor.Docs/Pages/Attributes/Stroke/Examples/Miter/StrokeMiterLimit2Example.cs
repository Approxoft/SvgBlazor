using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeMiterLimit2Example : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var stroke = new SvgStroke
            {
                Color = "black",
                LineJoin = StrokeLineJoinStyle.Miter,
                MiterLimit = 2,
                Width = 15,
            };

            var d = "m20, 172 c46, -77 76, -140 76, -140 c0, 0 23, 40 90, 140";

            var path = new SvgPath
            {
                Path = d,
                Stroke = stroke,
                Fill = new SvgFill
                {
                    Color = "none",
                },
            };

            var highlightPath = new SvgPath
            {
                Path = d,
                Stroke = new SvgStroke
                {
                    Color = "gold",
                    Width = 2,
                },
                Fill = new SvgFill { Color = "none" },
            };
            /* #example-code-end */

            svg.Add(path);
            svg.Add(highlightPath);
        }
    }
}