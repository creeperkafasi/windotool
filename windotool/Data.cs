using System;
using System.Collections.Generic;
using PInvoke;

namespace windotool
{
    public static class Data
    {
        public static readonly Dictionary<string, User32.VirtualKey> ControlKeys = new()
        {
            ["backspace"] = User32.VirtualKey.VK_BACK,
            ["return"] = User32.VirtualKey.VK_RETURN,
            ["ctrl"] = User32.VirtualKey.VK_LCONTROL,
            ["control"] = User32.VirtualKey.VK_CONTROL,
            ["control_l"] = User32.VirtualKey.VK_LCONTROL,
            ["control_r"] = User32.VirtualKey.VK_RCONTROL,
            ["shift"] = User32.VirtualKey.VK_SHIFT,
            ["shift_l"] = User32.VirtualKey.VK_LSHIFT,
            ["shift_r"] = User32.VirtualKey.VK_RIGHT,
            ["win"] = User32.VirtualKey.VK_LWIN,
            ["windows"] = User32.VirtualKey.VK_LWIN,
            ["super"] = User32.VirtualKey.VK_LWIN,
            ["space"] = User32.VirtualKey.VK_SPACE,
            ["delete"] = User32.VirtualKey.VK_DELETE,
            ["insert"] = User32.VirtualKey.VK_INSERT,
            ["home"] = User32.VirtualKey.VK_HOME,
            ["end"] = User32.VirtualKey.VK_END,
            ["pageup"] = User32.VirtualKey.VK_PRIOR,
            ["pagedown"] = User32.VirtualKey.VK_NEXT,
            ["tab"] = User32.VirtualKey.VK_TAB,

            ["f1"] = User32.VirtualKey.VK_F1,
            ["f2"] = User32.VirtualKey.VK_F2,
            ["f3"] = User32.VirtualKey.VK_F3,
            ["f4"] = User32.VirtualKey.VK_F4,
            ["f5"] = User32.VirtualKey.VK_F5,
            ["f6"] = User32.VirtualKey.VK_F6,
            ["f7"] = User32.VirtualKey.VK_F7,
            ["f8"] = User32.VirtualKey.VK_F8,
            ["f9"] = User32.VirtualKey.VK_F9,
            ["f10"] = User32.VirtualKey.VK_F10,
            ["f11"] = User32.VirtualKey.VK_F11,
            ["f12"] = User32.VirtualKey.VK_F12,
            ["f13"] = User32.VirtualKey.VK_F13,
            ["f14"] = User32.VirtualKey.VK_F14,
            ["f15"] = User32.VirtualKey.VK_F15,
            ["f16"] = User32.VirtualKey.VK_F16,
            ["f17"] = User32.VirtualKey.VK_F17,
            ["f18"] = User32.VirtualKey.VK_F18,
            ["f19"] = User32.VirtualKey.VK_F19,
            ["f20"] = User32.VirtualKey.VK_F20,
            ["f21"] = User32.VirtualKey.VK_F21,
            ["f22"] = User32.VirtualKey.VK_F22,
            ["f23"] = User32.VirtualKey.VK_F23,
            ["f24"] = User32.VirtualKey.VK_F24,

            ["up"] = User32.VirtualKey.VK_UP,
            ["down"] = User32.VirtualKey.VK_DOWN,
            ["left"] = User32.VirtualKey.VK_LEFT,
            ["right"] = User32.VirtualKey.VK_RIGHT,

            ["xf86audiolowervolume"] = User32.VirtualKey.VK_VOLUME_DOWN,
            ["volumeup"] = User32.VirtualKey.VK_VOLUME_DOWN,
            ["xf86audioraisevolume"] = User32.VirtualKey.VK_VOLUME_UP,
            ["volumedown"] = User32.VirtualKey.VK_VOLUME_DOWN,
            ["xf86audiomute"] = User32.VirtualKey.VK_VOLUME_MUTE,
            ["volumemute"] = User32.VirtualKey.VK_VOLUME_MUTE,

            // there is no single pause and play key in windows so both keys will just toggle
            ["xf86audiopause"] = User32.VirtualKey.VK_MEDIA_PLAY_PAUSE,
            ["xf86audioplay"] = User32.VirtualKey.VK_MEDIA_PLAY_PAUSE,
            ["mediaplaypause"] = User32.VirtualKey.VK_MEDIA_PLAY_PAUSE,
            ["xf86audiostop"] = User32.VirtualKey.VK_MEDIA_STOP,
            ["mediastop"] = User32.VirtualKey.VK_MEDIA_STOP,

            ["xf86audionext"] = User32.VirtualKey.VK_MEDIA_NEXT_TRACK,
            ["medianexttrack"] = User32.VirtualKey.VK_MEDIA_NEXT_TRACK,
            ["xf86audioprev"] = User32.VirtualKey.VK_MEDIA_PREV_TRACK,
            ["mediaprevtrack"] = User32.VirtualKey.VK_MEDIA_NEXT_TRACK,
        };

        public static readonly Dictionary<string, User32.MOUSEINPUT> MouseButtons = new()
        {
            ["1"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN,
            },
            ["3"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_RIGHTDOWN,
            },
            ["2"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_MIDDLEDOWN
            },
            ["4"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_WHEEL,
                mouseData = User32.WHEEL_DELTA,
            },
            ["5"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_WHEEL,
                mouseData = UInt32.MaxValue - User32.WHEEL_DELTA,
            },
            ["6"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_HWHEEL,
                mouseData = User32.WHEEL_DELTA,
            },
            ["7"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_HWHEEL,
                mouseData = UInt32.MaxValue - User32.WHEEL_DELTA,
            },
            ["8"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_XDOWN,
                mouseData = 1,
            },
            ["9"] = new()
            {
                dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_XDOWN,
                mouseData = 2,
            },
        };
    }
}