using System.ComponentModel;

namespace SvgBlazor
{
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
