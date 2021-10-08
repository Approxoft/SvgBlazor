using System;

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
        Arcs,

        /// <summary>
        /// The sharp corner will be used to join path segments.
        /// </summary>
        Miter,

        /// <summary>
        /// The bevelled corner will be used to join path segments.
        /// </summary>
        Bevel,

        /// <summary>
        /// The round corner will be used to join path segments.
        /// </summary>
        Round,
    }
}
