using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer.App_Code.Common
{
    enum VirtualKey : int
    {
        VK_LBUTTON = 0x01,
        VK_RBUTTON = 0x02,
        VK_CANCEL = 0x03,
        VK_MBUTTON = 0x04,

        [DisplayName("BACKSPACE")]
        VK_BACK = 0x08,

        [DisplayName("TAB")]
        VK_TAB = 0x09,
        
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,

        [DisplayName("PAUSE")]
        VK_PAUSE = 0x13,

        [DisplayName("CAPS LOCK")]
        VK_CAPITAL = 0x14,

        [DisplayName("ESC")]
        VK_ESCAPE = 0x1B,

        [DisplayName("SPACE")]
        VK_SPACE = 0x20,

        [DisplayName("PAGE UP")]
        VK_PRIOR = 0x21,

        [DisplayName("PAGE DOWN")]
        VK_NEXT = 0x22,

        [DisplayName("END")]
        VK_END = 0x23,

        [DisplayName("HOME")]
        VK_HOME = 0x24,

        [DisplayName("LEFT ARROW")]
        VK_LEFT = 0x25,

        [DisplayName("UP ARROW")]
        VK_UP = 0x26,

        [DisplayName("RIGHT ARROW")]
        VK_RIGHT = 0x27,

        [DisplayName("DOWN ARROW")]
        VK_DOWN = 0x28,

        VK_SELECT = 0x29,
        VK_EXECUTE = 0x2B,

        [DisplayName("PRINT SCREEN")]
        VK_SNAPSHOT = 0x2C,

        [DisplayName("INS")]
        VK_INSERT = 0x2D,

        [DisplayName("DEL")]
        VK_DELETE = 0x2E,

        [DisplayName("HELP")]
        VK_HELP = 0x2F,

        [DisplayName("0")]
        VK_0 = 0x30,

        [DisplayName("1")]
        VK_1 = 0x31,

        [DisplayName("2")]
        VK_2 = 0x32,

        [DisplayName("3")]
        VK_3 = 0x33,

        [DisplayName("4")]
        VK_4 = 0x34,

        [DisplayName("5")]
        VK_5 = 0x35,

        [DisplayName("6")]
        VK_6 = 0x36,

        [DisplayName("7")]
        VK_7 = 0x37,

        [DisplayName("8")]
        VK_8 = 0x38,

        [DisplayName("9")]
        VK_9 = 0x39,

        [DisplayName("A")]
        VK_A = 0x41,

        [DisplayName("B")]
        VK_B = 0x42,

        [DisplayName("C")]
        VK_C = 0x43,

        [DisplayName("D")]
        VK_D = 0x44,

        [DisplayName("E")]
        VK_E = 0x45,

        [DisplayName("F")]
        VK_F = 0x46,

        [DisplayName("G")]
        VK_G = 0x47,

        [DisplayName("H")]
        VK_H = 0x48,

        [DisplayName("I")]
        VK_I = 0x49,

        [DisplayName("J")]
        VK_J = 0x4A,

        [DisplayName("K")]
        VK_K = 0x4B,

        [DisplayName("L")]
        VK_L = 0x4C,

        [DisplayName("M")]
        VK_M = 0x4D,

        [DisplayName("N")]
        VK_N = 0x4E,

        [DisplayName("O")]
        VK_O = 0x4F,

        [DisplayName("P")]
        VK_P = 0x50,

        [DisplayName("Q")]
        VK_Q = 0x51,

        [DisplayName("R")]
        VK_R = 0x52,

        [DisplayName("S")]
        VK_S = 0x53,

        [DisplayName("T")]
        VK_T = 0x54,

        [DisplayName("U")]
        VK_U = 0x55,

        [DisplayName("V")]
        VK_V = 0x56,

        [DisplayName("W")]
        VK_W = 0x57,

        [DisplayName("X")]
        VK_X = 0x58,

        [DisplayName("Y")]
        VK_Y = 0x59,

        [DisplayName("Z")]
        VK_Z = 0x5A,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,

        [DisplayName("NUMPAD 0")]
        VK_NUMPAD0 = 0x60,

        [DisplayName("NUMPAD 1")]
        VK_NUMPAD1 = 0x61,

        [DisplayName("NUMPAD 2")]
        VK_NUMPAD2 = 0x62,

        [DisplayName("NUMPAD 3")]
        VK_NUMPAD3 = 0x63,

        [DisplayName("NUMPAD 4")]
        VK_NUMPAD4 = 0x64,

        [DisplayName("NUMPAD 5")]
        VK_NUMPAD5 = 0x65,

        [DisplayName("NUMPAD 6")]
        VK_NUMPAD6 = 0x66,

        [DisplayName("NUMPAD 7")]
        VK_NUMPAD7 = 0x67,

        [DisplayName("NUMPAD 8")]
        VK_NUMPAD8 = 0x68,

        [DisplayName("NUMPAD 9")]
        VK_NUMPAD9 = 0x69,

        [DisplayName("MULTIPLY")]
        VK_MULTIPLY = 0x6A,

        [DisplayName("ADD")]
        VK_ADD = 0x6B,

        [DisplayName("SEPARATOR")]
        VK_SEPARATOR = 0x6C,

        [DisplayName("SUBTRACT")]
        VK_SUBTRACT = 0x6D,

        [DisplayName("DECIMAL")]
        VK_DECIMAL = 0x6E,

        [DisplayName("DIVIDE")]
        VK_DIVIDE = 0x6F,

        [DisplayName("F1")]
        VK_F1 = 0x70,

        [DisplayName("F2")]
        VK_F2 = 0x71,

        [DisplayName("F3")]
        VK_F3 = 0x72,

        [DisplayName("F4")]
        VK_F4 = 0x73,

        [DisplayName("F5")]
        VK_F5 = 0x74,

        [DisplayName("F6")]
        VK_F6 = 0x75,

        [DisplayName("F7")]
        VK_F7 = 0x76,

        [DisplayName("F8")]
        VK_F8 = 0x77,

        [DisplayName("F9")]
        VK_F9 = 0x78,

        [DisplayName("F10")]
        VK_F10 = 0x79,

        [DisplayName("F11")]
        VK_F11 = 0x7A,

        [DisplayName("F12")]
        VK_F12 = 0x7B,

        [DisplayName("F13")]
        VK_F13 = 0x7C,

        [DisplayName("F14")]
        VK_F14 = 0x7D,

        [DisplayName("F15")]
        VK_F15 = 0x7E,

        [DisplayName("F16")]
        VK_F16 = 0x7F,

        [DisplayName("F17")]
        VK_F17 = 0x80,

        [DisplayName("F18")]
        VK_F18 = 0x81,

        [DisplayName("F19")]
        VK_F19 = 0x82,

        [DisplayName("F20")]
        VK_F20 = 0x83,

        [DisplayName("F21")]
        VK_F21 = 0x84,

        [DisplayName("F22")]
        VK_F22 = 0x85,

        [DisplayName("F23")]
        VK_F23 = 0x86,

        [DisplayName("F24")]
        VK_F24 = 0x87,

        [DisplayName("NUM LOCK")]
        VK_NUMLOCK = 0x90,

        [DisplayName("SCROLL LOCK")]
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
