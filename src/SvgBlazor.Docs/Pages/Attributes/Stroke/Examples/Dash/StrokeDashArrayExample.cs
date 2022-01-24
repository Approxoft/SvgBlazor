// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class StrokeDashArrayExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var dashArrayStroke = new SvgStroke
            {
                Color = "green",
                Width = 15,
                DashArray = "1 2",
            };
            /* #example-code-end */

            var circle = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 75,
                Stroke = dashArrayStroke,
            };

            svg.Add(circle);
        }
    }
}