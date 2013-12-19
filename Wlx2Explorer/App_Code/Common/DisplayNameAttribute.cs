using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer.App_Code.Common
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    class DisplayNameAttribute : Attribute
    {
        public String DisplayName { get; private set; }

        public DisplayNameAttribute(String displayName) : base()
        {
            DisplayName = displayName;
        }
    }
}
