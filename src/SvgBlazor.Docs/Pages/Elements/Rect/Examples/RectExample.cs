// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class RectExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var rect = new SvgRect
            {
                X = 10,
                Y = 20,
                Width = 180,
                Height = 180,
                Fill = new SvgFill { Color = "purple" },
            };
            /* #example-code-end */

            svg.Add(rect);
        }
    }
}
