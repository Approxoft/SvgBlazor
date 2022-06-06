// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class SvgUseExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var circle = new SvgCircle
            {
                Id = "circleId",
                CenterX = 40,
                CenterY = 40,
                Radius = 40,
                Fill = new SvgFill { Color = "blue" },
            };

            var svgUse1 = new SvgUse
            {
                X = 120,
                Y = 0,
                Element = circle,
            };

            var svgUse2 = new SvgUse
            {
                X = 0,
                Y = 120,
                Element = circle,
            };

            var svgUse3 = new SvgUse
            {
                X = 120,
                Y = 120,
                Element = circle,
            };

            /* #example-code-end */
            svg.Add(circle);
            svg.Add(svgUse1);
            svg.Add(svgUse2);
            svg.Add(svgUse3);
        }
    }
}