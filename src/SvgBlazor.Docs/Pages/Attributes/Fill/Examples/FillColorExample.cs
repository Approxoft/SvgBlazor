// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class FillColorExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var fill1 = new SvgFill { Color = "red" };

            var fill2 = new SvgFill { Color = "green" };

            var fill3 = new SvgFill { Color = "blue" };
            /* #example-code-end */

            var circle1 = new SvgCircle
            {
                CenterX = 100,
                CenterY = 100,
                Radius = 75,
                Fill = fill1,
            };

            var circle2 = new SvgCircle
            {
                CenterX = 200,
                CenterY = 100,
                Radius = 75,
                Fill = fill2,
            };

            var circle3 = new SvgCircle
            {
                CenterX = 300,
                CenterY = 100,
                Radius = 75,
                Fill = fill3,
            };

            svg.Add(circle1);
            svg.Add(circle2);
            svg.Add(circle3);
        }
    }
}