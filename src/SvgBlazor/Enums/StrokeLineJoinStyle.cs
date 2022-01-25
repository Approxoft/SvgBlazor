// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// The stroke's line join styles.
    /// </summary>
    public enum StrokeLineJoinStyle
    {
        /// <summary>
        /// The arcs shape will be used to join path segments.
        /// </summary>
        [Description("arcs")]
        Arcs,

        /// <summary>
        /// The sharp corner will be used to join path segments.
        /// </summary>
        [Description("miter")]
        Miter,

        /// <summary>
        /// The sharp corner will be used to join path segments.
        /// </summary>
        [Description("miter-clip")]
        MiterClip,

        /// <summary>
        /// The bevelled corner will be used to join path segments.
        /// </summary>
        [Description("bevel")]
        Bevel,

        /// <summary>
        /// The round corner will be used to join path segments.
        /// </summary>
        [Description("round")]
        Round,
    }
}
