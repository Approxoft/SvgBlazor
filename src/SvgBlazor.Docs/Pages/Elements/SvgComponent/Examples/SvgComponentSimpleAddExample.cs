﻿using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class SvgComponentSimpleAddExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            var circle = new SvgCircle
            {
                CenterX = 50,
                CenterY = 50,
                Radius = 25,
            };

            svg.Add(circle);
            /* #example-code-end */
        }
    }
}