﻿// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeMiterLimitExamples : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var noMiterLimitPath = new SvgPath
            {
                Path = "m 15 70 l 85 -49 l 85 50",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    LineJoin = StrokeLineJoinStyle.Miter,
                    Width = 30,
                },
                Fill = new SvgFill
                {
                    Color = "none",
                },
            };

            var miterLimit1Path = new SvgPath
            {
                Path = "m 15 130 l 85 -49 l 85 50",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    LineJoin = StrokeLineJoinStyle.Miter,
                    Width = 30,
                    MiterLimit = 1,
                },
                Fill = new SvgFill
                {
                    Color = "none",
                },
            };

            var miterLimit2Path = new SvgPath
            {
                Path = "m 15 200 l 85 -49 l 85 50",
                Stroke = new SvgStroke
                {
                    Color = "black",
                    LineJoin = StrokeLineJoinStyle.Miter,
                    Width = 30,
                    MiterLimit = 2,
                },
                Fill = new SvgFill
                {
                    Color = "none",
                },
            };

            /* #example-code-end */
            svg.Add(noMiterLimitPath);
            svg.Add(miterLimit1Path);
            svg.Add(miterLimit2Path);
        }
    }
}
