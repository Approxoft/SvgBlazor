// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextTextAnchorExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            DrawLines(svg);
            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 200,
                    Y = 30,
                    Text = "Let's drop the anchor",
                    TextAnchor = TextAnchor.Start,
                };
                /* #example-code-end */
                svg.Add(text);
            }

            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 200,
                    Y = 60,
                    Text = "Let's drop the anchor",
                    TextAnchor = TextAnchor.Middle,
                };
                /* #example-code-end */
                svg.Add(text);
            }

            {
                /* #example-code-start */
                var text = new SvgText
                {
                    X = 200,
                    Y = 90,
                    Text = "Let's drop the anchor",
                    TextAnchor = TextAnchor.End,
                };
                /* #example-code-end */
                svg.Add(text);
            }

            DrawCircles(svg);
        }

        private void DrawLines(SvgComponent svg)
        {
            var path = new SvgPath();
            path.Path = "M200,0 L200,110 M0,30 L400,30 M0,60 L400,60 M0,90 L400,90";
            path.Stroke = new SvgStroke
            {
                Color = "lightgray",
                DashArray = "4",
            };

            svg.Add(path);
        }

        private void DrawCircles(SvgComponent svg)
        {
            var circle1 = new SvgCircle
            {
                CenterX = 200,
                CenterY = 30,
                Radius = 3,
                Fill = new SvgFill
                {
                    Color = "red",
                },
            };

            var circle2 = new SvgCircle(circle1);
            circle2.CenterY = 60;

            var circle3 = new SvgCircle(circle1);
            circle3.CenterY = 90;

            svg.Add(circle1);
            svg.Add(circle2);
            svg.Add(circle3);
        }
    }
}