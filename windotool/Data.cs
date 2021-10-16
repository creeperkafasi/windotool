using System.Collections.Generic;
using PInvoke;

namespace windotool
{
    public static class Data
    {
        public static List<string> Actions = new()
        {
            "key",
            "keydown",
            "keyup",
            "type",
            "sleep",
        };
        
        
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
        };
    }
}