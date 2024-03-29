// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgBlazor.Interfaces;

namespace SvgBlazor
{
    /// <summary>
    /// The root element for SVG drawings.
    /// </summary>
    public class Svg : SvgContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Svg"/> class.
        /// </summary>
        public Svg()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Svg"/> class with provided Svg element.
        /// </summary>
        /// <param name="svg">Initial Svg element.</param>
        public Svg(Svg svg)
            : base(svg)
        {
            Width = svg.Width;
            Height = svg.Height;
            ViewBoxWidth = svg.ViewBoxWidth;
            ViewBoxHeight = svg.ViewBoxHeight;
        }

        /// <summary>
        /// Gets or sets the width of the svg element. Optional.
        /// </summary>
        public float? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the svg element. Optional.
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Gets or sets the optional width of the viewbox. If not set, the 'Width' value will be used.
        /// </summary>
        public float? ViewBoxWidth { get; set; }

        /// <summary>
        /// Gets or sets the optional height of the viewbox. If not set, the 'Height' value will be used.
        /// </summary>
        public float? ViewBoxHeight { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "svg";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            base.AddAttributes(builder);
            builder.AddAttribute(1, "viewBox", string.Format("0 0 {0} {1}", ViewBoxWidth ?? Width ?? 0, ViewBoxHeight ?? Height ?? 0));

            if (Width is not null)
            {
                builder.AddAttribute(2, "width", Width);
            }

            if (Height is not null)
            {
                builder.AddAttribute(3, "height", Height);
            }
        }

        /// <summary>
        /// Sets the size of the viewbox and redraws the svg.
        /// </summary>
        /// <param name="width">Width of the viewbox.</param>
        /// <param name="height">Height of the viewbox.</param>
        public void SetViewBox(float width, float height)
        {
            ViewBoxWidth = width;
            ViewBoxHeight = height;
        }

        /// <summary>
        /// Sets the size of the viewport and redraws the svg.
        /// </summary>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        public void SetSize(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
