using System;
using System.ComponentModel;

namespace SvgBlazor.Extensions
{
    public static class EnumExtension
    {
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
