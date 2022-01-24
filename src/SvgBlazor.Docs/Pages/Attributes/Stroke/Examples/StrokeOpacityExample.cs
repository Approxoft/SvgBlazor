// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeOpacityExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var stroke = new SvgStroke
            {
                Color = "yellow",
                Width = 15,
                Opacity = 0.5f,
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