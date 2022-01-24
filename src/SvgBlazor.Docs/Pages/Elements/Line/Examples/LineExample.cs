// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class LineExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var line = new SvgLine
            {
                X1 = 0,
                Y1 = 0,
                X2 = 200,
                Y2 = 200,
                Stroke = new SvgStroke { Color = "red" },
            };
            /* #example-code-end */

            svg.Add(line);
        }
    }
}
