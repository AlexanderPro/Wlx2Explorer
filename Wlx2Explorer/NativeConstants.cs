using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer
{
    static class NativeConstants
    {
        public const int WM_COMMAND = 0x0111;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_KEYDOWN = 0x0100;
        public const int WH_KEYBOARD_LL = 0x0D;
        public const UInt32 HC_ACTION = 0;

        public const int LCS_FINDFIRST = 0x01;
        public const int LCS_MATCHCASE = 0x02;
        public const int LCS_WHOLEWORDS = 0x04;
        public const int LCS_BACKWARDS = 0x08;
    }
}
