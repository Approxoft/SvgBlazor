﻿// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class EllipseExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var ellipse = new SvgEllipse
            {
                CenterX = 100,
                CenterY = 100,
                RadiusX = 40,
                RadiusY = 20,
                Fill = new SvgFill { Color = "orange" },
            };
            /* #example-code-end */

            svg.Add(ellipse);
        }
    }
}
