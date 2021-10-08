using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeMiterLimitExample : IExampleCode
    {
        private int? _miterLimit;

        public StrokeMiterLimitExample(int? miterLimit = null) => _miterLimit = miterLimit;

        public void Example(SvgComponent svg)
        {
            var path = new SvgPath
            {
                Path = "m3,85 c5,-3 90,-73 90,-73 c0,0 100,75 100,75",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    LineJoin = StrokeLineJoinStyle.Miter,
                    MiterLimit = _miterLimit,
                    Width = 15,
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
