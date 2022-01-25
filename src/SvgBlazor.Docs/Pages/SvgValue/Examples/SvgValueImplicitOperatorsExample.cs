// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using SvgBlazor.Docs.Interfaces;

namespace SvgBlazor.Docs.Examples
{
    public class SvgValueImplicitOperatorsExample : IExampleCode
    {
        public void Example(SvgComponent svg)
        {
            /* #example-code-start */
            SvgValue svgValueInt = 10;
            SvgValue svgValueFloat = 10F;
            SvgValue svgValueString = "10";
            /* #example-code-end */
        }
    }
}
