// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

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
            /* #example-code-end */

            svg.Add(lineButt);
            svg.Add(lineRound);
            svg.Add(lineSquare);
        }
    }
}