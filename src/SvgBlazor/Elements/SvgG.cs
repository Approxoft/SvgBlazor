﻿// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgG class is responsible for providing the SVG group element.
    /// </summary>
    public partial class SvgG : SvgContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgG"/> class.
        /// </summary>
        public SvgG()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgG"/> class with provided SvgG.
        /// </summary>
        /// <param name="svgg">Initial SvgG.</param>
        public SvgG(SvgG svgg)
            : base(svgg)
        {
        }

        /// <inheritdoc/>
        public override string Tag() => "g";
    }
}
