// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// The stroke's line cap styles.
    /// </summary>
    public enum StrokeLineCapStyle
    {
        /// <summary>
        /// The end of each subpath will not be extended beyond its two endpoints.
        /// </summary>
        [Description("butt")]
        Butt,

        /// <summary>
        /// The end of each subpath will be extended by a rectangle.
        /// </summary>
        [Description("square")]
        Square,

        /// <summary>
        /// The end of each subpath will be extended by a half circle.
        /// </summary>
        [Description("round")]
        Round,
    }
}
