using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineJoinExamples : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var minterPath = new SvgPath
            {
                Path = "m 15 86 c 0 0 125 0 71 -49 c 58 13 65 21 65 52",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 25,
                    LineJoin = StrokeLineJoinStyle.Miter,
                },
                Fill = new SvgFill { Color = "none" },
            };

            var roundPath = new SvgPath
            {
                Path = "m 15 186 c 0 0 125 0 71 -49 c 58 13 65 21 65 52",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 25,
                    LineJoin = StrokeLineJoinStyle.Round,
                },
                Fill = new SvgFill { Color = "none" },
            };

            var bevelPath = new SvgPath
            {
                Path = "m 15 286 c 0 0 125 0 71 -49 c 58 13 65 21 65 52",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 25,
                    LineJoin = StrokeLineJoinStyle.Bevel,
                },
                Fill = new SvgFill { Color = "none" },
            };

            var miterClipPath = new SvgPath
            {
                Path = "m 15 386 c 0 0 125 0 71 -49 c 58 13 65 21 65 52",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 25,
                    LineJoin = StrokeLineJoinStyle.MiterClip,
                },
                Fill = new SvgFill { Color = "none" },
            };

            var arcsPath = new SvgPath
            {
                Path = "m 15 486 c 0 0 125 0 71 -49 c 58 13 65 21 65 52",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 25,
                    LineJoin = StrokeLineJoinStyle.Arcs,
                },
                Fill = new SvgFill { Color = "none" },
            };

            /* #example-code-end */
            svg.Add(minterPath);
            svg.Add(roundPath);
            svg.Add(bevelPath);
            svg.Add(miterClipPath);
            svg.Add(arcsPath);
        }
    }
}
