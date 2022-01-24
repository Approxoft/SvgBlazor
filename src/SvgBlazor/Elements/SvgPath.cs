// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgPath class is responsible for providing the SVG path element.
    /// </summary>
    public class SvgPath : SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgPath"/> class.
        /// </summary>
        public SvgPath()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgPath"/> class with provided SvgPath.
        /// </summary>
        /// <param name="svgpath">Initial SvgPath.</param>
        public SvgPath(SvgPath svgpath)
            : base(svgpath)
        {
            Path = svgpath.Path;
        }

        /// <summary>
        /// Gets or sets the d string representing the actual path.
        /// </summary>
        public string Path { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "path";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);

            builder.AddAttribute(0, "d", Path);
        }
    }
}
