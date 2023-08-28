using System;
using System.Linq;
using System.ComponentModel;

namespace Wlx2Explorer.Extensions
{
    static class EnumExtensions
    {
        public static string GetDescription(this Enum value) => 
            value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>()?.FirstOrDefault()?.Description ?? string.Empty;
    }
}
