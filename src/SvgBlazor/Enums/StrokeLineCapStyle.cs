using System;

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
        Butt,

        /// <summary>
        /// The end of each subpath will be extended by a rectangle.
        /// </summary>
        Square,

        /// <summary>
        /// The end of each subpath will be extended by a half circle.
        /// </summary>
        Round,
    }
}
