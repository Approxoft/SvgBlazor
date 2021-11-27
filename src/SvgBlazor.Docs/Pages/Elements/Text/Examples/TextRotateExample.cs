﻿using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class TextRotateExample : TextBasicExample
    {
        public override void Example(SvgComponent svg)
        {
            base.Example(svg);
            /* #example-code-start */
            Text.Rotate = "20 0 20";
            /* #example-code-end */
        }
    }
}