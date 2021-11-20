using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using PInvoke;

namespace windotool
{
    public static class Functions
    {
        public static void Key(string key, bool isUp)
        {
            User32.INPUT[] inputs = new User32.INPUT[1];
            if (isUp) inputs[0].Inputs.ki.dwFlags = User32.KEYEVENTF.KEYEVENTF_KEYUP;
            if (Data.ControlKeys.Keys.Contains(key.ToLower()))
            {
                inputs[0].type = User32.InputType.INPUT_KEYBOARD;
                inputs[0].Inputs.ki.wVk = Data.ControlKeys[key];
                User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
            }
            else
            {
                inputs[0].type = User32.InputType.INPUT_KEYBOARD;
                inputs[0].Inputs.ki.dwFlags = inputs[0].Inputs.ki.dwFlags | User32.KEYEVENTF.KEYEVENTF_UNICODE;
                inputs[0].Inputs.ki.wScan = (User32.ScanCode) key[0];
                User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
            }
        }

        public static void Type(string str)
        {
            foreach (var ch in str)
            {
                Key(ch.ToString(), false);
                Key(ch.ToString(), true);
            }
        }

        public static void MouseMove(int x, int y, bool isRelative)
        {
            User32.INPUT[] inputs = new User32.INPUT[1];
            inputs[0].type = User32.InputType.INPUT_MOUSE;
            inputs[0].Inputs.mi.dx = x;
            inputs[0].Inputs.mi.dy = y;
            inputs[0].Inputs.mi.dwFlags =
                User32.MOUSEEVENTF.MOUSEEVENTF_MOVE
                | (!isRelative ? User32.MOUSEEVENTF.MOUSEEVENTF_ABSOLUTE : 0);
            User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
        }

        public static void MouseButton(string btn, bool isDown)
        {
            var inputs = new[]
            {
                new User32.INPUT()
                {
                    type = User32.InputType.INPUT_MOUSE,
                    Inputs =
                    {
                        mi = Data.MouseButtons[btn],
                    }
                }
            };
            inputs[0].Inputs.mi.dwFlags =
                (User32.MOUSEEVENTF) (((UInt32) (inputs[0].Inputs.mi.dwFlags)) << (isDown ? 1 : 0));
            User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
        }
    }
}