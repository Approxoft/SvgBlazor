// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TexDominantBaselineExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            DrawLines(svg);
            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 10,
                    Y = 30,
                    Text = "Auto",
                    DominantBaseline = TextDominantBaseline.Auto,
                };
                /* #example-code-end */
                svg.Add(text);
            }

            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 10,
                    Y = 60,
                    Text = "Middle",
                    DominantBaseline = TextDominantBaseline.Middle,
                };
                /* #example-code-end */
                svg.Add(text);
            }

            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 10,
                    Y = 90,
                    Text = "Hanging",
                    DominantBaseline = TextDominantBaseline.Hanging,
                };
                /* #example-code-end */
                svg.Add(text);
            }
        }

        private void DrawLines(SvgComponent svg)
        {
            var path = new SvgPath();
            path.Path = "M0,30 L200,30 M0,60 L200,60 M0,90 L200,90";
            path.Stroke = new SvgStroke
            {
                Color = "lightgray",
                DashArray = "4",
            };

            svg.Add(path);
        }
    }
}