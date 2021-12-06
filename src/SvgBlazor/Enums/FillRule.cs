using System.ComponentModel;

namespace SvgBlazor
{
    /// <summary>
    /// The rule that determines which parts of the canvas are contained within the shape.
    /// </summary>
    public enum FillRule
    {
        /// <summary>
        /// Non zero fill rule.
        /// </summary>
        [Description("nonzero")]
        NonZero,

        /// <summary>
        /// Even odd fill rule.
        /// </summary>
        [Description("evenodd")]
        EvenOdd,
    }
}
