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
                        bool usePolarCoords = false;

                        while (args.Count - 1 > i && args[i + 1].StartsWith("--"))
                        {
                            switch (args[i + 1])
                            {
                                case "--":
                                    i++;
                                    break;
                                case "--polar":
                                    usePolarCoords = true;
                                    i++;
                                    break;
                            }
                        }

                        double x = Double.Parse(args[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                        double y = Double.Parse(args[i + 2], System.Globalization.CultureInfo.InvariantCulture);

                        if (usePolarCoords)
                        {
                            double radians = ((360 - x) + 90) * Math.PI / 180;
                            double distance = y;

                            int originX = screenSize[0] / 2;
                            int originY = screenSize[1] / 2;

                            x = originX + (Math.Cos(radians) * y);
                            y = originY + (-Math.Sin(radians) * y);
                        }

                        Functions.MouseMove(
                            Convert.ToInt32(x / screenSize[0] * 65535),
                            Convert.ToInt32(y / screenSize[1] * 65535),
                            false);

                        i += 2;
                        return 0;
                    },
                    ["mousemove_relative"] = () =>
                    {
                        bool usePolarCoords = false;

                        while (args.Count - 1 > i && args[i + 1].StartsWith("--"))
                        {
                            switch (args[i + 1])
                            {
                                case "--":
                                    i++;
                                    break;
                                case "--polar":
                                    usePolarCoords = true;
                                    i++;
                                    break;
                            }
                        }

                        double x = Double.Parse(args[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                        double y = Double.Parse(args[i + 2], System.Globalization.CultureInfo.InvariantCulture);

                        if (usePolarCoords)
                        {
                            double radians = ((360 - x) + 90) * Math.PI / 180;
                            double distance = y;

                            x = (Math.Cos(radians) * y);
                            y = (-Math.Sin(radians) * y);
                        }

                        Functions.MouseMove(
                            Convert.ToInt32(x),
                            Convert.ToInt32(y),
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
                    },
                    ["getmouselocation"] = () =>
                    {
                        while (args.Count - 1 > i && args[i + 1].StartsWith("--"))
                        {
                            switch (args[i + 1])
                            {
                                case "--":
                                    i++;
                                    break;
                                case "--shell":
                                    Console.WriteLine(
                                        "X={0}\nY={1}\nSCREEN={2}\nWINDOW={3}",
                                        User32.GetCursorPos().x,
                                        User32.GetCursorPos().y,
                                        0, // idk how to get the screen id in win32api... 
                                        User32.GetForegroundWindow()
                                    );
                                    i++;
                                    return 0;
                            }
                        }

                        Console.WriteLine(
                            "x:{0} y:{1} screen:{2} window:{3}",
                            User32.GetCursorPos().x,
                            User32.GetCursorPos().y,
                            0, // idk how to get the screen id in win32api... 
                            User32.GetForegroundWindow()
                        );
                        return 0;
                    },
                };

                if (commands.ContainsKey(args[i])) commands[args[i]].Invoke();
            }
        }
    }
}