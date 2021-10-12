using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineJoinExample : IExampleCode
    {
        private StrokeLineJoinStyle _strokeLineJoinStyle;

        public StrokeLineJoinExample(StrokeLineJoinStyle strokeLineJoinStyle) => _strokeLineJoinStyle = strokeLineJoinStyle;

        public void Example(SvgComponent svg)
        {
            var path = new SvgPath
            {
                Path = "m3,85 c5,-3 90,0 90,-73 c0,0 100,75 100,75",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 10,
                    LineJoin = _strokeLineJoinStyle,
                },
                Fill = new SvgFill
                {
                    Color = "none",
                },
            };

            svg.Add(path);
        }
    }
}
