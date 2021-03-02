using System.ComponentModel;

namespace Wlx2Explorer.Hooks
{
    enum VirtualKey : int
    {
        VK_LBUTTON = 0x01,
        VK_RBUTTON = 0x02,
        VK_CANCEL = 0x03,
        VK_MBUTTON = 0x04,

        [Description("BACKSPACE")]
        VK_BACK = 0x08,

        [Description("TAB")]
        VK_TAB = 0x09,
        
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,

        [Description("PAUSE")]
        VK_PAUSE = 0x13,

        [Description("CAPS LOCK")]
        VK_CAPITAL = 0x14,

        [Description("ESC")]
        VK_ESCAPE = 0x1B,

        [Description("SPACE")]
        VK_SPACE = 0x20,

        [Description("PAGE UP")]
        VK_PRIOR = 0x21,

        [Description("PAGE DOWN")]
        VK_NEXT = 0x22,

        [Description("END")]
        VK_END = 0x23,

        [Description("HOME")]
        VK_HOME = 0x24,

        [Description("LEFT ARROW")]
        VK_LEFT = 0x25,

        [Description("UP ARROW")]
        VK_UP = 0x26,

        [Description("RIGHT ARROW")]
        VK_RIGHT = 0x27,

        [Description("DOWN ARROW")]
        VK_DOWN = 0x28,

        VK_SELECT = 0x29,
        VK_EXECUTE = 0x2B,

        [Description("PRINT SCREEN")]
        VK_SNAPSHOT = 0x2C,

        [Description("INS")]
        VK_INSERT = 0x2D,

        [Description("DEL")]
        VK_DELETE = 0x2E,

        [Description("HELP")]
        VK_HELP = 0x2F,

        [Description("0")]
        VK_0 = 0x30,

        [Description("1")]
        VK_1 = 0x31,

        [Description("2")]
        VK_2 = 0x32,

        [Description("3")]
        VK_3 = 0x33,

        [Description("4")]
        VK_4 = 0x34,

        [Description("5")]
        VK_5 = 0x35,

        [Description("6")]
        VK_6 = 0x36,

        [Description("7")]
        VK_7 = 0x37,

        [Description("8")]
        VK_8 = 0x38,

        [Description("9")]
        VK_9 = 0x39,

        [Description("A")]
        VK_A = 0x41,

        [Description("B")]
        VK_B = 0x42,

        [Description("C")]
        VK_C = 0x43,

        [Description("D")]
        VK_D = 0x44,

        [Description("E")]
        VK_E = 0x45,

        [Description("F")]
        VK_F = 0x46,

        [Description("G")]
        VK_G = 0x47,

        [Description("H")]
        VK_H = 0x48,

        [Description("I")]
        VK_I = 0x49,

        [Description("J")]
        VK_J = 0x4A,

        [Description("K")]
        VK_K = 0x4B,

        [Description("L")]
        VK_L = 0x4C,

        [Description("M")]
        VK_M = 0x4D,

        [Description("N")]
        VK_N = 0x4E,

        [Description("O")]
        VK_O = 0x4F,

        [Description("P")]
        VK_P = 0x50,

        [Description("Q")]
        VK_Q = 0x51,

        [Description("R")]
        VK_R = 0x52,

        [Description("S")]
        VK_S = 0x53,

        [Description("T")]
        VK_T = 0x54,

        [Description("U")]
        VK_U = 0x55,

        [Description("V")]
        VK_V = 0x56,

        [Description("W")]
        VK_W = 0x57,

        [Description("X")]
        VK_X = 0x58,

        [Description("Y")]
        VK_Y = 0x59,

        [Description("Z")]
        VK_Z = 0x5A,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,

        [Description("NUMPAD 0")]
        VK_NUMPAD0 = 0x60,

        [Description("NUMPAD 1")]
        VK_NUMPAD1 = 0x61,

        [Description("NUMPAD 2")]
        VK_NUMPAD2 = 0x62,

        [Description("NUMPAD 3")]
        VK_NUMPAD3 = 0x63,

        [Description("NUMPAD 4")]
        VK_NUMPAD4 = 0x64,

        [Description("NUMPAD 5")]
        VK_NUMPAD5 = 0x65,

        [Description("NUMPAD 6")]
        VK_NUMPAD6 = 0x66,

        [Description("NUMPAD 7")]
        VK_NUMPAD7 = 0x67,

        [Description("NUMPAD 8")]
        VK_NUMPAD8 = 0x68,

        [Description("NUMPAD 9")]
        VK_NUMPAD9 = 0x69,

        [Description("MULTIPLY")]
        VK_MULTIPLY = 0x6A,

        [Description("ADD")]
        VK_ADD = 0x6B,

        [Description("SEPARATOR")]
        VK_SEPARATOR = 0x6C,

        [Description("SUBTRACT")]
        VK_SUBTRACT = 0x6D,

        [Description("DECIMAL")]
        VK_DECIMAL = 0x6E,

        [Description("DIVIDE")]
        VK_DIVIDE = 0x6F,

        [Description("F1")]
        VK_F1 = 0x70,

        [Description("F2")]
        VK_F2 = 0x71,

        [Description("F3")]
        VK_F3 = 0x72,

        [Description("F4")]
        VK_F4 = 0x73,

        [Description("F5")]
        VK_F5 = 0x74,

        [Description("F6")]
        VK_F6 = 0x75,

        [Description("F7")]
        VK_F7 = 0x76,

        [Description("F8")]
        VK_F8 = 0x77,

        [Description("F9")]
        VK_F9 = 0x78,

        [Description("F10")]
        VK_F10 = 0x79,

        [Description("F11")]
        VK_F11 = 0x7A,

        [Description("F12")]
        VK_F12 = 0x7B,

        [Description("F13")]
        VK_F13 = 0x7C,

        [Description("F14")]
        VK_F14 = 0x7D,

        [Description("F15")]
        VK_F15 = 0x7E,

        [Description("F16")]
        VK_F16 = 0x7F,

        [Description("F17")]
        VK_F17 = 0x80,

        [Description("F18")]
        VK_F18 = 0x81,

        [Description("F19")]
        VK_F19 = 0x82,

        [Description("F20")]
        VK_F20 = 0x83,

        [Description("F21")]
        VK_F21 = 0x84,

        [Description("F22")]
        VK_F22 = 0x85,

        [Description("F23")]
        VK_F23 = 0x86,

        [Description("F24")]
        VK_F24 = 0x87,

        [Description("NUM LOCK")]
        VK_NUMLOCK = 0x90,

        [Description("SCROLL LOCK")]
        VK_SCROLL = 0x91,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5,
        VK_PACKET = 0xE7,
        VK_ATTN = 0xF6,
        VK_CRSEL = 0xF7,
        VK_EXSEL = 0xF8,
        VK_EREOF = 0xF9,
        VK_PLAY = 0xFA,
        VK_ZOOM = 0xFB,
        VK_NONAME = 0xFC,
        VK_PA1 = 0xFD,
    }
}
