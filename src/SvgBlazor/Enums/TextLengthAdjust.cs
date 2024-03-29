﻿// Copyright (c) Approxoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// The lengthAdjust attribute sets how the text is stretched to the length specified by the textLength attribute.
    /// </summary>
    public enum TextLengthAdjust
    {
        /// <summary>
        /// Adjusts only the spacing between the glyphs.
        /// </summary>
        [Description("spacing")]
        Spacing,

        /// <summary>
        /// Adjust spacing and glyph size.
        /// </summary>
        [Description("spacingAndGlyphs")]
        SpacingAndGlyphs,
    }
}
