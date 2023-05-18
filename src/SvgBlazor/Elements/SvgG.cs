// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace SvgBlazor
{
    public record SvgPoint(double X, double Y)
    {
        public static SvgPoint operator + (SvgPoint point1, SvgPoint point2) =>
            new SvgPoint(point1.X + point2.X, point1.Y + point2.Y);
    }

    /// <summary>
    /// The SvgG class is responsible for providing the SVG group element.
    /// </summary>
    public partial class SvgG : SvgContainer
    {
        // TODO: refactor + docs
        public SvgPoint? Translate { get; set; } // TODO: move to SvgElement

        public SvgPoint? Scale { get; set; } // TODO: move to SvgElement

        public SvgPoint? TransformOrigin { get; set; }

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

        public override void AddAttributes(RenderTreeBuilder builder)
        {
            var transform = MakeTransform();
            var transformOrigin = MakeTransformOrigin();

            if (transform is not null)
            {
                builder.AddAttribute(0, "transform", transform);
            }

            if (transformOrigin is not null)
            {
                builder.AddAttribute(1, "transform-origin", transformOrigin);
            }

            base.AddAttributes(builder);
        }

        private string? MakeTransformOrigin() // TODO: move to seperate class + unit test
        {
            if (TransformOrigin is not null)
            {
                return $"{TransformOrigin.X} {TransformOrigin.Y}";
            }

            return null;
        }

        private string? MakeTransform() // TODO: move to seperate class + unit test
        {
            var transform = string.Empty;

            if (Scale is not null)
            {
                transform += $"scale ({Scale.X} {Scale.Y})";
            }

            if (Translate is not null)
            {
                transform += transform.Length > 0 ? " " : string.Empty;
                transform += $"translate ({Translate.X} {Translate.Y})";
            }

            return transform != string.Empty ? transform : null;
        }
    }
}
