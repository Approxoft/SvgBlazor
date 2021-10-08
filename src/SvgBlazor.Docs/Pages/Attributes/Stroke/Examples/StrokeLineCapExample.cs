using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineCapExample : IExampleCode
    {
        private StrokeLineCapStyle? _strokeLineCapStyle;

        public StrokeLineCapExample(StrokeLineCapStyle? strokeLineCapStyle = null) => _strokeLineCapStyle = strokeLineCapStyle;

        public void Example(SvgComponent svg)
        {
            var line = new SvgLine
            {
                X1 = 10,
                Y1 = 5,
                X2 = 175,
                Y2 = 5,
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 10,
                    LineCap = _strokeLineCapStyle,
                },
            };

            svg.Add(line);
        }
    }
}