namespace Wlx2Explorer.Native
{
    static class NativeConstants
    {
        public const int WM_COMMAND = 0x0111;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WH_KEYBOARD_LL = 0x0D;

        public const uint HC_ACTION = 0;

        public const int LCS_FINDFIRST = 0x01;
        public const int LCS_MATCHCASE = 0x02;
        public const int LCS_WHOLEWORDS = 0x04;
        public const int LCS_BACKWARDS = 0x08;

        public const uint LVM_FIRST = 0x1000;
        public const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        public const uint LVM_GETITEMW = LVM_FIRST + 75;
        public const uint LVM_GETITEMPOSITION = LVM_FIRST + 16;
        public const uint LVM_GETITEMSTATE = LVM_FIRST + 44;        

        public const uint PROCESS_VM_OPERATION = 0x0008;
        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;

        public const uint MEM_COMMIT = 0x1000;
        public const uint MEM_RELEASE = 0x8000;
        public const uint MEM_RESERVE = 0x2000;

        public const uint PAGE_READWRITE = 4;
        public const int LVIF_TEXT = 0x0001;
        public const uint LVIS_SELECTED = 0x2;
    }
}
