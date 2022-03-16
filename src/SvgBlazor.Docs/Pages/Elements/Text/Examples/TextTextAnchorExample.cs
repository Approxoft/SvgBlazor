// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextTextAnchorExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
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
        }
    }
}