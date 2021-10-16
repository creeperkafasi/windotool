using System;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;

namespace windotool
{
    public static class Windotool
    {
        public static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length; i++)
            {
                if (Data.Actions.Contains(args[i]))
                {
                    switch (args[i])
                    {
                        case "key":
                            Functions.Key(args[i + 1], false);
                            Functions.Key(args[i + 1], true);
                            i++;
                            break;
                        case "keydown":
                            Functions.Key(args[i + 1], false);
                            i++;
                            break;
                        case "keyup":
                            Functions.Key(args[i + 1], true);
                            i++;
                            break;
                        case "type":
                            Functions.Type(args[i + 1]);
                            i++;
                            break;
                        case "sleep":
                            Thread.Sleep(Convert.ToInt32(Double.Parse(args[i + 1]) * 1000));
                            i++;
                            break;
                    }
                }
            }

            // while (args.Length < 3)
            // {
            //     Console.WriteLine("No arguments passed, reading from stdin");
            //     args = ("windotool " + Console.ReadLine()).Split(" ");
            // }
            //
            // switch (args[1])
            // {
            //     case "key":
            //         Functions.Key(args[2], false);
            //         Functions.Key(args[2], true);
            //         break;
            //     case "keydown":
            //         Functions.Key(args[2], false);
            //         break;
            //     case "keyup":
            //         Functions.Key(args[2], true);
            //         break;
            // }

            // inputs[0].type = User32.InputType.INPUT_MOUSE;
            // inputs[0].Inputs.mi.dx = 10;
            // inputs[0].Inputs.mi.dy = inputs[0].Inputs.mi.dx;
            // inputs[0].Inputs.mi.dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_MOVE;
            //
            // for (int i = 0; i < 20; i++)
            // {
            //     User32.SendInput(inputs.Length, inputs, Marshal.SizeOf(typeof(User32.INPUT)));
            //     Thread.Sleep(1);
            // }
        }
    }
}