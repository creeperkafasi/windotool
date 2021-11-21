using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using SharpDX.DirectInput;

namespace windotool
{
    public static class Windotool
    {
        public static void Main()
        {
            int[] screenSize =
            {
                User32.GetSystemMetrics(User32.SystemMetric.SM_CXSCREEN),
                User32.GetSystemMetrics(User32.SystemMetric.SM_CYSCREEN)
            };

            List<string> args = Environment.GetCommandLineArgs().ToList();

            foreach (var el in args)
            {
                Console.WriteLine(el);
            }

            for (int i = 0; i < args.Count; i++)
            {
                var commands = new Dictionary<string, Func<int>>()
                {
                    ["key"] = () =>
                    {
                        Functions.Key(args[i + 1], false);
                        Functions.Key(args[i + 1], true);
                        i++;
                        return 0;
                    },
                    ["keydown"] = () =>
                    {
                        Functions.Key(args[i + 1], false);
                        i++;
                        return 0;
                    },

                    ["keyup"] = () =>
                    {
                        Functions.Key(args[i + 1], true);
                        i++;
                        return 0;
                    },
                    ["type"] = () =>
                    {
                        for (int j = i + 1; j < args.Count; j++)
                        {
                            Functions.Type(args[j]);

                            if (j + 1 != args.Count)
                                Functions.Type(" ");
                        }

                        i = args.Count - 1;
                        return 0;
                    },
                    ["sleep"] = () =>
                    {
                        Thread.Sleep(Convert.ToInt32(Double.Parse(args[i + 1]) * 1000));
                        return 0;
                    },
                    ["mousemove"] = () =>
                    {
                        if (args[i + 1] == "--") i++;
                        Functions.MouseMove(
                            Convert.ToInt32((float) Convert.ToInt32(args[i + 1]) / screenSize[0] * 65535),
                            Convert.ToInt32((float) Convert.ToInt32(args[i + 2]) / screenSize[1] * 65535),
                            false);
                        i += 2;
                        return 0;
                    },
                    ["mousemove_relative"] = () =>
                    {
                        if (args[i + 1] == "--") i++;
                        Functions.MouseMove(
                            Convert.ToInt32(args[i + 1]),
                            Convert.ToInt32(args[i + 2]),
                            true);
                        i += 2;
                        return 0;
                    },
                    ["click"] = () =>
                    {
                        Functions.MouseButton(args[i + 1], false);
                        Functions.MouseButton(args[i + 1], true);
                        i++;
                        return 0;
                    },
                    ["mousedown"] = () =>
                    {
                        Functions.MouseButton(args[i + 1], false);
                        i++;
                        return 0;
                    },
                    ["mouseup"] = () =>
                    {
                        Functions.MouseButton(args[i + 1], true);
                        i++;
                        return 0;
                    }
                };

                if (commands.ContainsKey(args[i])) commands[args[i]].Invoke();
            }
        }
    }
}