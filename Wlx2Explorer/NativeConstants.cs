using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer
{
    static class NativeConstants
    {
        public const Int32 WM_COMMAND = 0x0111;
        public const Int32 WM_NOTIFY = 0x004E;
        public const Int32 WM_MEASUREITEM = 0x002C;
        public const Int32 WM_DRAWITEM = 0x002B;
        public const Int32 WM_KEYDOWN = 0x0100;
        public const Int32 WH_KEYBOARD_LL = 0x0D;
        public const UInt32 HC_ACTION = 0;

        public const Int32 LCS_FINDFIRST = 0x01;
        public const Int32 LCS_MATCHCASE = 0x02;
        public const Int32 LCS_WHOLEWORDS = 0x04;
        public const Int32 LCS_BACKWARDS = 0x08;
    }
}
