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
                return;
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
            User32.INPUT[] inputs = new User32.INPUT[1];
            foreach (char ch in str)
            {
                inputs[0].type = User32.InputType.INPUT_KEYBOARD;
                inputs[0].Inputs.ki.dwFlags = User32.KEYEVENTF.KEYEVENTF_UNICODE;
                inputs[0].Inputs.ki.wScan = (User32.ScanCode) ch;
                User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
                inputs[0].Inputs.ki.dwFlags = User32.KEYEVENTF.KEYEVENTF_UNICODE | User32.KEYEVENTF.KEYEVENTF_KEYUP;
                User32.SendInput(1, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
            }
        }
    }
}