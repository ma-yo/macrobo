using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models
{/// <summary>
/// Author : M.Yoshida
/// 仮想キーボードのキーコード
/// </summary>
    public class VirtualKeyCode
    {

        /// <summary>
        /// マウスの左ボタン
        /// </summary>
        public const byte VK_LBUTTON = 0x01;
        /// <summary>
        /// マウスの右ボタン
        /// </summary>
        public const byte VK_RBUTTON = 0x02;
        /// <summary>
        /// コントロール・ブレイク処理
        /// </summary>
        public const byte VK_CANCEL = 0x03;
        /// <summary>
        /// マウスの中央ボタン
        /// </summary>
        public const byte VK_MBUTTON = 0x04;
        /// <summary>
        /// マウスの第一拡張ボタン
        /// </summary>
        public const byte VK_XBUTTON1 = 0x05;
        /// <summary>
        /// マウスの第2拡張ボタン
        /// </summary>
        public const byte VK_XBUTTON2 = 0x06;
        /// <summary>
        /// Backspaceキー
        /// </summary>
        public const byte VK_BACK = 0x08;
        /// <summary>
        /// Tabキー
        /// </summary>
        public const byte VK_TAB = 0x09;
        /// <summary>
        /// Clearキー
        /// </summary>
        public const byte VK_CLEAR = 0x0C;
        /// <summary>
        /// Enterキー
        /// </summary>
        public const byte VK_RETURN = 0x0D;
        /// <summary>
        /// Shiftキー
        /// </summary>
        public const byte VK_SHIFT = 0x10;
        /// <summary>
        /// Ctrlキー
        /// </summary>
        public const byte VK_CONTROL = 0x11;
        /// <summary>
        /// Altキー
        /// </summary>
        public const byte VK_MENU = 0x12;
        /// <summary>
        /// Pauseキー
        /// </summary>
        public const byte VK_PAUSE = 0x13;
        /// <summary>
        /// CapsLockキー
        /// </summary>
        public const byte VK_CAPITAL = 0x14;
        /// <summary>
        /// IMEかなモード
        /// </summary>
        public const byte VK_KANA = 0x15;
        /// <summary>
        /// IME Junjaモード
        /// </summary>
        public const byte VK_JUNJA = 0x17;
        /// <summary>
        /// IME ファイナルモード
        /// </summary>
        public const byte VK_FINAL = 0x18;
        /// <summary>
        /// IME 漢字モード
        /// </summary>
        public const byte VK_KANJI = 0x19;
        /// <summary>
        /// Escキー
        /// </summary>
        public const byte VK_ESCAPE = 0x1B;
        /// <summary>
        /// IME 変換
        /// </summary>
        public const byte VK_CONVERT = 0x1C;
        /// <summary>
        /// IME 無変換
        /// </summary>
        public const byte VK_NONCONVERT = 0x1D;
        /// <summary>
        /// IME 使用可能
        /// </summary>
        public const byte VK_ACCEPT = 0x1E;
        /// <summary>
        /// IME モード変更要求
        /// </summary>
        public const byte VK_MODECHANGE = 0x1F;
        /// <summary>
        /// スペースキー
        /// </summary>
        public const byte VK_SPACE = 0x20;
        /// <summary>
        /// PageUpキー
        /// </summary>
        public const byte VK_PRIOR = 0x21;
        /// <summary>
        /// PageDownキー
        /// </summary>
        public const byte VK_NEXT = 0x22;
        /// <summary>
        /// Endキー
        /// </summary>
        public const byte VK_END = 0x23;
        /// <summary>
        /// Homeキー
        /// </summary>
        public const byte VK_HOME = 0x24;
        /// <summary>
        /// ←キー
        /// </summary>
        public const byte VK_LEFT = 0x25;
        /// <summary>
        /// ↑キー
        /// </summary>
        public const byte VK_UP = 0x26;
        /// <summary>
        /// →キー
        /// </summary>
        public const byte VK_RIGHT = 0x27;
        /// <summary>
        /// ↓キー
        /// </summary>
        public const byte VK_DOWN = 0x28;
        /// <summary>
        /// Selectキー
        /// </summary>
        public const byte VK_SELECT = 0x29;
        /// <summary>
        /// Printキー
        /// </summary>
        public const byte VK_PRINT = 0x2A;
        /// <summary>
        /// Executeキー
        /// </summary>
        public const byte VK_EXECUTE = 0x2B;
        /// <summary>
        /// PrintScreenキー
        /// </summary>
        public const byte VK_SNAPSHOT = 0x2C;
        /// <summary>
        /// Insertキー
        /// </summary>
        public const byte VK_INSERT = 0x2D;
        /// <summary>
        /// Deleteキー
        /// </summary>
        public const byte VK_DELETE = 0x2E;
        /// <summary>
        /// Helpキー
        /// </summary>
        public const byte VK_HELP = 0x2F;
        /// <summary>
        /// 0キー
        /// </summary>
        public const byte VK_0 = 0x30;
        /// <summary>
        /// 1キー
        /// </summary>
        public const byte VK_1 = 0x31;
        /// <summary>
        /// 2キー
        /// </summary>
        public const byte VK_2 = 0x32;
        /// <summary>
        /// 3キー
        /// </summary>
        public const byte VK_3 = 0x33;
        /// <summary>
        /// 4キー
        /// </summary>
        public const byte VK_4 = 0x34;
        /// <summary>
        /// 5キー
        /// </summary>
        public const byte VK_5 = 0x35;
        /// <summary>
        /// 6キー
        /// </summary>
        public const byte VK_6 = 0x36;
        /// <summary>
        /// 7キー
        /// </summary>
        public const byte VK_7 = 0x37;
        /// <summary>
        /// 8キー
        /// </summary>
        public const byte VK_8 = 0x38;
        /// <summary>
        /// 9キー
        /// </summary>
        public const byte VK_9 = 0x39;
        /// <summary>
        /// Aキー
        /// </summary>
        public const byte VK_A = 0x41;
        /// <summary>
        /// Bキー
        /// </summary>
        public const byte VK_B = 0x42;
        /// <summary>
        /// Cキー
        /// </summary>
        public const byte VK_C = 0x43;
        /// <summary>
        /// Dキー
        /// </summary>
        public const byte VK_D = 0x44;
        /// <summary>
        /// Eキー
        /// </summary>
        public const byte VK_E = 0x45;
        /// <summary>
        /// Fキー
        /// </summary>
        public const byte VK_F = 0x46;
        /// <summary>
        /// Gキー
        /// </summary>
        public const byte VK_G = 0x47;
        /// <summary>
        /// Hキー
        /// </summary>
        public const byte VK_H = 0x48;
        /// <summary>
        /// Iキー
        /// </summary>
        public const byte VK_I = 0x49;
        /// <summary>
        /// Jキー
        /// </summary>
        public const byte VK_J = 0x4A;
        /// <summary>
        /// Kキー
        /// </summary>
        public const byte VK_K = 0x4B;
        /// <summary>
        /// Lキー
        /// </summary>
        public const byte VK_L = 0x4C;
        /// <summary>
        /// Mキー
        /// </summary>
        public const byte VK_M = 0x4D;
        /// <summary>
        /// Nキー
        /// </summary>
        public const byte VK_N = 0x4E;
        /// <summary>
        /// Oキー
        /// </summary>
        public const byte VK_O = 0x4F;
        /// <summary>
        /// Pキー
        /// </summary>
        public const byte VK_P = 0x50;
        /// <summary>
        /// Qキー
        /// </summary>
        public const byte VK_Q = 0x51;
        /// <summary>
        /// Rキー
        /// </summary>
        public const byte VK_R = 0x52;
        /// <summary>
        /// Sキー
        /// </summary>
        public const byte VK_S = 0x53;
        /// <summary>
        /// Tキー
        /// </summary>
        public const byte VK_T = 0x54;
        /// <summary>
        /// Uキー
        /// </summary>
        public const byte VK_U = 0x55;
        /// <summary>
        /// Vキー
        /// </summary>
        public const byte VK_V = 0x56;
        /// <summary>
        /// Wキー
        /// </summary>
        public const byte VK_W = 0x57;
        /// <summary>
        /// Xキー
        /// </summary>
        public const byte VK_X = 0x58;
        /// <summary>
        /// Yキー
        /// </summary>
        public const byte VK_Y = 0x59;
        /// <summary>
        /// Zキー
        /// </summary>
        public const byte VK_Z = 0x5A;
        /// <summary>
        /// 左Windowsキー
        /// </summary>
        public const byte VK_LWIN = 0x5B;
        /// <summary>
        /// 右Windowsキー
        /// </summary>
        public const byte VK_RWIN = 0x5C;
        /// <summary>
        /// アプリケーションキー
        /// </summary>
        public const byte VK_APPS = 0x5D;
        /// <summary>
        /// コンピュータスリープキー
        /// </summary>
        public const byte VK_SLEEP = 0x5F;
        /// <summary>
        /// テンキーの0キー
        /// </summary>
        public const byte VK_NUMPAD0 = 0x60;
        /// <summary>
        /// テンキーの1キー
        /// </summary>
        public const byte VK_NUMPAD1 = 0x61;
        /// <summary>
        /// テンキーの2キー
        /// </summary>
        public const byte VK_NUMPAD2 = 0x62;
        /// <summary>
        /// テンキーの3キー
        /// </summary>
        public const byte VK_NUMPAD3 = 0x63;
        /// <summary>
        /// テンキーの4キー
        /// </summary>
        public const byte VK_NUMPAD4 = 0x64;
        /// <summary>
        /// テンキーの5キー
        /// </summary>
        public const byte VK_NUMPAD5 = 0x65;
        /// <summary>
        /// テンキーの6キー
        /// </summary>
        public const byte VK_NUMPAD6 = 0x66;
        /// <summary>
        /// テンキーの7キー
        /// </summary>
        public const byte VK_NUMPAD7 = 0x67;
        /// <summary>
        /// テンキーの8キー
        /// </summary>
        public const byte VK_NUMPAD8 = 0x68;
        /// <summary>
        /// テンキーの9キー
        /// </summary>
        public const byte VK_NUMPAD9 = 0x69;
        /// <summary>
        /// テンキーの*キー
        /// </summary>
        public const byte VK_MULTIPLY = 0x6A;
        /// <summary>
        /// テンキーの+キー
        /// </summary>
        public const byte VK_ADD = 0x6B;
        /// <summary>
        /// 区切り記号キー
        /// </summary>
        public const byte VK_SEPARATOR = 0x6C;
        /// <summary>
        /// テンキーの-キー
        /// </summary>
        public const byte VK_SUBTRACT = 0x6D;
        /// <summary>
        /// テンキーの.キー
        /// </summary>
        public const byte VK_DECIMAL = 0x6E;
        /// <summary>
        /// テンキーの/キー
        /// </summary>
        public const byte VK_DIVIDE = 0x6F;
        /// <summary>
        /// F1キー
        /// </summary>
        public const byte VK_F1 = 0x70;
        /// <summary>
        /// F2キー
        /// </summary>
        public const byte VK_F2 = 0x71;
        /// <summary>
        /// F3キー
        /// </summary>
        public const byte VK_F3 = 0x72;
        /// <summary>
        /// F4キー
        /// </summary>
        public const byte VK_F4 = 0x73;
        /// <summary>
        /// F5キー
        /// </summary>
        public const byte VK_F5 = 0x74;
        /// <summary>
        /// F6キー
        /// </summary>
        public const byte VK_F6 = 0x75;
        /// <summary>
        /// F7キー
        /// </summary>
        public const byte VK_F7 = 0x76;
        /// <summary>
        /// F8キー
        /// </summary>
        public const byte VK_F8 = 0x77;
        /// <summary>
        /// F9キー
        /// </summary>
        public const byte VK_F9 = 0x78;
        /// <summary>
        /// F10キー
        /// </summary>
        public const byte VK_F10 = 0x79;
        /// <summary>
        /// F11キー
        /// </summary>
        public const byte VK_F11 = 0x7A;
        /// <summary>
        /// F12キー
        /// </summary>
        public const byte VK_F12 = 0x7B;
        /// <summary>
        /// F13キー
        /// </summary>
        public const byte VK_F13 = 0x7C;
        /// <summary>
        /// F14キー
        /// </summary>
        public const byte VK_F14 = 0x7D;
        /// <summary>
        /// F15キー
        /// </summary>
        public const byte VK_F15 = 0x7E;
        /// <summary>
        /// F16キー
        /// </summary>
        public const byte VK_F16 = 0x7F;
        /// <summary>
        /// F17キー
        /// </summary>
        public const byte VK_F17 = 0x80;
        /// <summary>
        /// F18キー
        /// </summary>
        public const byte VK_F18 = 0x81;
        /// <summary>
        /// F19キー
        /// </summary>
        public const byte VK_F19 = 0x82;
        /// <summary>
        /// F20キー
        /// </summary>
        public const byte VK_F20 = 0x83;
        /// <summary>
        /// F21キー
        /// </summary>
        public const byte VK_F21 = 0x84;
        /// <summary>
        /// F22キー
        /// </summary>
        public const byte VK_F22 = 0x85;
        /// <summary>
        /// F23キー
        /// </summary>
        public const byte VK_F23 = 0x86;
        /// <summary>
        /// F24キー
        /// </summary>
        public const byte VK_F24 = 0x87;
        /// <summary>
        /// NumLockキー
        /// </summary>
        public const byte VK_NUMLOCK = 0x90;
        /// <summary>
        /// ScrollLockキー
        /// </summary>
        public const byte VK_SCROLL = 0x91;
        /// <summary>
        /// 左Shiftキー
        /// </summary>
        public const byte VK_LSHIFT = 0xA0;
        /// <summary>
        /// 右Shiftキー
        /// </summary>
        public const byte VK_RSHIFT = 0xA1;
        /// <summary>
        /// 左Controlキー
        /// </summary>
        public const byte VK_LCONTROL = 0xA2;
        /// <summary>
        /// 右Controlキー
        /// </summary>
        public const byte VK_RCONTROL = 0xA3;
        /// <summary>
        /// 左Altキー
        /// </summary>
        public const byte VK_LMENU = 0xA4;
        /// <summary>
        /// 右Altキー
        /// </summary>
        public const byte VK_RMENU = 0xA5;
        /// <summary>
        /// ブラウザの戻るキー
        /// </summary>
        public const byte VK_BROWSER_BACK = 0xA6;
        /// <summary>
        /// ブラウザの進むキー
        /// </summary>
        public const byte VK_BROWSER_FORWARD = 0xA7;
        /// <summary>
        /// ブラウザの更新キー
        /// </summary>
        public const byte VK_BROWSER_REFRESH = 0xA8;
        /// <summary>
        /// ブラウザの停止キー
        /// </summary>
        public const byte VK_BROWSER_STOP = 0xA9;
        /// <summary>
        /// ブラウザの検索キー
        /// </summary>
        public const byte VK_BROWSER_SEARCH = 0xAA;
        /// <summary>
        /// ブラウザのお気に入りキー
        /// </summary>
        public const byte VK_BROWSER_FAVORITES = 0xAB;
        /// <summary>
        /// ブラウザの開始ホームキー
        /// </summary>
        public const byte VK_BROWSER_HOME = 0xAC;
        /// <summary>
        /// 音量ミュートキー
        /// </summary>
        public const byte VK_VOLUME_MUTE = 0xAD;
        /// <summary>
        /// 音量ダウンキー
        /// </summary>
        public const byte VK_VOLUME_DOWN = 0xAE;
        /// <summary>
        /// 音量アップキー
        /// </summary>
        public const byte VK_VOLUME_UP = 0xAF;
        /// <summary>
        /// 次のトラックキー
        /// </summary>
        public const byte VK_MEDIA_NEXT_TRACK = 0xB0;
        /// <summary>
        /// 前のトラックキー
        /// </summary>
        public const byte VK_MEDIA_PREV_TRACK = 0xB1;
        /// <summary>
        /// メディア停止キー
        /// </summary>
        public const byte VK_MEDIA_STOP = 0xB2;
        /// <summary>
        /// メディア再生/一時停止キー
        /// </summary>
        public const byte VK_MEDIA_PLAY_PAUSE = 0xB3;
        /// <summary>
        /// メール起動キー
        /// </summary>
        public const byte VK_LAUNCH_MAIL = 0xB4;
        /// <summary>
        /// メディア選択キー
        /// </summary>
        public const byte VK_LAUNCH_MEDIA_SELECT = 0xB5;
        /// <summary>
        /// アプリケーション1起動キー
        /// </summary>
        public const byte VK_LAUNCH_APP1 = 0xB6;
        /// <summary>
        /// アプリケーション2起動キー
        /// </summary>
        public const byte VK_LAUNCH_APP2 = 0xB7;
        /// <summary>
        /// OEMキー
        /// </summary>
        public const byte VK_OEM_1 = 0xBA;
        /// <summary>
        /// +キー
        /// </summary>
        public const byte VK_OEM_PLUS = 0xBB;
        /// <summary>
        /// ,キー
        /// </summary>
        public const byte VK_OEM_COMMA = 0xBC;
        /// <summary>
        /// -キー
        /// </summary>
        public const byte VK_OEM_MINUS = 0xBD;
        /// <summary>
        /// .キー
        /// </summary>
        public const byte VK_OEM_PERIOD = 0xBE;
        /// <summary>
        /// OEM2キー
        /// </summary>
        public const byte VK_OEM_2 = 0xBF;
        /// <summary>
        /// OEM3キー
        /// </summary>
        public const byte VK_OEM_3 = 0xC0;
        /// <summary>
        /// OEM4キー
        /// </summary>
        public const byte VK_OEM_4 = 0xDB;
        /// <summary>
        /// OEM5キー
        /// </summary>
        public const byte VK_OEM_5 = 0xDC;
        /// <summary>
        /// OEM6キー
        /// </summary>
        public const byte VK_OEM_6 = 0xDD;
        /// <summary>
        /// OEM7キー
        /// </summary>
        public const byte VK_OEM_7 = 0xDE;
        /// <summary>
        /// OEM8キー
        /// </summary>
        public const byte VK_OEM_8 = 0xDF;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_AX = 0xE1;
        /// <summary>
        /// OEM102キー
        /// </summary>
        public const byte VK_OEM_102 = 0xE2;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_ICO_HELP = 0xE3;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_ICO_00 = 0xE4;
        /// <summary>
        /// IME PROCESSキー
        /// </summary>
        public const byte VK_PROCESSKEY = 0xE5;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_ICO_CLEAR = 0xE6;
        /// <summary>
        /// キーボード以外の入力手段に使用される32 ビット仮想キー値の下位ワード
        /// </summary>
        public const byte VK_PACKET = 0xE7;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_RESET = 0xE9;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_JUMP = 0xEA;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_PA1 = 0xEB;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_PA2 = 0xEC;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_PA3 = 0xED;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_WSCTRL = 0xEE;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_CUSEL = 0xEF;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_ATTN = 0xF0;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_FINISH = 0xF1;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_COPY = 0xF2;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_AUTO = 0xF3;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_ENLW = 0xF4;
        /// <summary>
        /// OEM固有
        /// </summary>
        public const byte VK_OEM_BACKTAB = 0xF5;
        /// <summary>
        /// Attnキー
        /// </summary>
        public const byte VK_ATTN = 0xF6;
        /// <summary>
        /// CrSelキー
        /// </summary>
        public const byte VK_CRSEL = 0xF7;
        /// <summary>
        /// ExSelキー
        /// </summary>
        public const byte VK_EXSEL = 0xF8;
        /// <summary>
        /// Erase EOFキー
        /// </summary>
        public const byte VK_EREOF = 0xF9;
        /// <summary>
        /// Playキー
        /// </summary>
        public const byte VK_PLAY = 0xFA;
        /// <summary>
        /// Zoomキー
        /// </summary>
        public const byte VK_ZOOM = 0xFB;

        public const byte VK_NONAME = 0xFC;
        /// <summary>
        /// PA1キー
        /// </summary>
        public const byte VK_PA1 = 0xFD;
        /// <summary>
        /// Clearキー
        /// </summary>
        public const byte VK_OEM_CLEAR = 0xFE;

    }
}
