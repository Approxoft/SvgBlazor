using System;
using System.ComponentModel;

namespace SvgBlazor
{
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
