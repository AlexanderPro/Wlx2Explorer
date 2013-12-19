using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Wlx2Explorer.App_Code.Common
{
    static class EnumExtensions
    {
        public static String GetDisplayName(this System.Enum value)
        {
            var displayName = value.ToString();
            var fieldInfo = value.GetType().GetField(displayName);
            var attributes = (DisplayNameAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            displayName = (attributes != null && attributes.Length > 0) ? attributes[0].DisplayName : null;
            return displayName;
        }
    }
}
