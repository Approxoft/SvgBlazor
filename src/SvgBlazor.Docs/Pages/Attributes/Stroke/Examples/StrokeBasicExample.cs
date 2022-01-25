// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeBasicExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var stroke = new SvgStroke
            {
                Color = "pink",
                Width = 15,
            };
            /* #example-code-end */

            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 75,
                Stroke = stroke,
            };

            svg.Add(circle);
        }
    }
}