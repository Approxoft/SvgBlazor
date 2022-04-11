// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// Specifies the baseline used to align the text.
    /// </summary>
    public enum TextDominantBaseline
    {
        /// <summary>
        /// Auto alignment.
        /// </summary>
        [Description("auto")]
        Auto,

        /// <summary>
        /// Text bottom alignment.
        /// </summary>
        [Description("text-bottom")]
        TextBottom,

        /// <summary>
        /// Alphabetic alignment.
        /// </summary>
        [Description("alphabetic")]
        Alphabetic,

        /// <summary>
        /// Ideographic alignment.
        /// </summary>
        [Description("ideographic")]
        Ideographic,

        /// <summary>
        /// Middle alignment.
        /// </summary>
        [Description("middle")]
        Middle,

        /// <summary>
        /// Central alignment.
        /// </summary>
        [Description("central")]
        Central,

        /// <summary>
        /// Mathematical alignment.
        /// </summary>
        [Description("mathematical")]
        Mathematical,

        /// <summary>
        /// Hanging alignment.
        /// </summary>
        [Description("hanging")]
        Hanging,

        /// <summary>
        /// Text top alignment.
        /// </summary>
        [Description("text-top")]
        TextTop,
    }
}