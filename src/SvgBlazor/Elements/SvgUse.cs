// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    /// <summary>
    /// The SvgUse class is responsible for providing the SVG use element.
    /// </summary>
    public class SvgUse : SvgElement
    {
        /// <summary>
        /// Gets or sets the element to duplicate.
        /// </summary>
        public SvgElement Element { get; set; }

        /// <summary>
        /// Gets or sets the width of the duplicated element.
        /// </summary>
        public SvgValue Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the duplicated element.
        /// </summary>
        public SvgValue Height { get; set; }

        /// <inheritdoc/>
        public override string Tag() => "use";

        /// <inheritdoc/>
        public override void AddAttributes(RenderTreeBuilder builder)
        {
            if (Element is null)
            {
                throw new Exception("Element to duplicate is not provided");
            }

            var elementId = Element.Id;

            if (string.IsNullOrWhiteSpace(elementId))
            {
                throw new Exception("When using use element an id of the element to duplicate must be provided");
            }

            builder.AddAttribute(1, "href", $"#{elementId}");
            builder.AddAttribute(2, "x", X);
            builder.AddAttribute(3, "y", Y);
            builder.AddAttribute(4, "width", Width);
            builder.AddAttribute(5, "height", Height);
        }
    }
}