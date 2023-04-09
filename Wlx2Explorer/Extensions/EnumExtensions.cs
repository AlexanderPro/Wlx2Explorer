using System;
using System.Linq;
using System.ComponentModel;

namespace Wlx2Explorer.Extensions
{
    static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description;
        }
    }
}
