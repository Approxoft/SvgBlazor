// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class PathExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var line = new SvgPath()
            {
                Path = "M 10, 30 " +
                "A 20, 20 0, 0, 1 50, 30 " +
                "A 20, 20 0, 0, 1 90, 30 " +
                "Q 90, 60 50, 90 " +
                "Q 10, 60 10, 30 z",
                Fill = new SvgFill { Color = "pink" },
                Stroke = new SvgStroke { Color = "red" },
            };
            /* #example-code-end */

            svg.Add(line);
        }
    }
}
