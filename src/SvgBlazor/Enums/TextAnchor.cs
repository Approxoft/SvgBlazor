// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// The anchor of the text.
    /// </summary>
    public enum TextAnchor
    {
        /// <summary>
        /// The given x and y coordinates will become the start location of the text.
        /// </summary>
        [Description("start")]
        Start,

        /// <summary>
        /// The given x and y coordinates will become the middle location of the text.
        /// </summary>
        [Description("middle")]
        Middle,

        /// <summary>
        /// The given x and y coordinates will become the end location of the text.
        /// </summary>
        [Description("end")]
        End,
    }
}