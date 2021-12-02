using System;
using SvgBlazor.Docs.Interfaces;
using SvgBlazor.Elements;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeLineCapExamples : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var lineButt = new SvgLine
            {
                X1 = 15,
                Y1 = 15,
                X2 = 185,
                Y2 = 15,
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 30,
                    LineCap = StrokeLineCapStyle.Butt,
                },
            };

            var lineRound = new SvgLine
            {
                X1 = 15,
                Y1 = 75,
                X2 = 185,
                Y2 = 75,
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 30,
                    LineCap = StrokeLineCapStyle.Round,
                },
            };

            var lineSquare = new SvgLine
            {
                X1 = 15,
                Y1 = 135,
                X2 = 185,
                Y2 = 135,
                Stroke = new SvgStroke
                {
                    Color = "black",
                    Width = 30,
                    LineCap = StrokeLineCapStyle.Square,
                },
            };

            var highlight = new SvgPath
            {
                Path = "M 15 15 H 185 M 15 75 H 185 M 15 135 H 185",
                Stroke = new SvgStroke
                {
                    Color = "darkgrey",
                    Width = 1,
                },
            };

            var line1circle1 = new SvgCircle
            {
                CenterX = 15,
                CenterY = 15,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            var line1circle2 = new SvgCircle
            {
                CenterX = 185,
                CenterY = 15,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            var line2circle1 = new SvgCircle
            {
                CenterX = 15,
                CenterY = 75,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            var line2circle2 = new SvgCircle
            {
                CenterX = 185,
                CenterY = 75,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            var line3circle1 = new SvgCircle
            {
                CenterX = 15,
                CenterY = 135,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            var line3circle2 = new SvgCircle
            {
                CenterX = 185,
                CenterY = 135,
                Radius = 2,
                Fill = new SvgFill
                {
                    Color = "darkgrey",
                },
            };

            /* #example-code-end */

            svg.Add(lineButt);
            svg.Add(lineRound);
            svg.Add(lineSquare);
            svg.Add(highlight);
            svg.Add(line1circle1);
            svg.Add(line1circle2);
            svg.Add(line2circle1);
            svg.Add(line2circle2);
            svg.Add(line3circle1);
            svg.Add(line3circle2);
        }
    }
}