using System;
using System.Collections.Generic;
using PInvoke;

namespace windotool
{
    public static class Data
    {
        public static Dictionary<string, User32.VirtualKey> ControlKeys = new()
        {
            ["backspace"] = User32.VirtualKey.VK_BACK,
            ["return"] = User32.VirtualKey.VK_RETURN,
            ["ctrl"] = User32.VirtualKey.VK_LCONTROL,
            ["control"] = User32.VirtualKey.VK_LCONTROL,
            ["control_l"] = User32.VirtualKey.VK_LCONTROL,
            ["control_r"] = User32.VirtualKey.VK_RCONTROL,
            ["win"] = User32.VirtualKey.VK_LWIN,
            ["windows"] = User32.VirtualKey.VK_LWIN,
            ["super"] = User32.VirtualKey.VK_LWIN,
            ["space"] = User32.VirtualKey.VK_SPACE,
        };

        public static Dictionary<string, User32.MOUSEINPUT> MouseButtons = new Dictionary<string, User32.MOUSEINPUT>()
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