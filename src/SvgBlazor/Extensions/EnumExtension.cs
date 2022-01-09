using System;
using System.ComponentModel;

namespace SvgBlazor.Extensions
{
    /// <summary>
    /// Extensions for enum.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Gets the DescriptionAttribute of the enum.
        /// </summary>
        /// <param name="en">The enum to get the description.</param>
        /// <returns>The DescriptionAttribute of the enum.</returns>
        public static string ToDescriptionString(this Enum en)
        {
            var attributes = (DescriptionAttribute[])en
                .GetType()
                .GetField(en.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : en.ToString();
        }
    }
}
