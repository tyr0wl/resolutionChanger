using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ResolutionChanger.Data.Modes;
using ResolutionChanger.Data.Paths;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes;
using ResolutionChanger.Win32.DisplayConfig.Paths;
using SystemConsole = System.Console;

namespace ResolutionChanger.Console
{
    internal class Program
    {
        public static Dictionary<uint, string> friendlyMonitors = new ();

        private static void Main(string[] args)
        {
            var monitors = Win32ApiWrapper.GetMonitors();

            var setup = args.FirstOrDefault();
            if (setup == "a")
            {
                SetSetupA(monitors);
            }
            else
            {
                SetSetupB(monitors);
            }
        }

        private static void SetSetupA(IList<Monitor> monitors)
        {
            var lc32G7 = monitors.First(monitor => monitor.DisplayName.Contains("LC32G7"));
            var vg279 = monitors.First(monitor => monitor.DisplayName == "VG279");
            var tv = monitors.First(monitor => monitor.DisplayName == "SAMSUNG");
            var eizo = monitors.First(monitor => monitor.DisplayName == "S2231W");

            tv.IsActive = true;
            tv.IsPrimary = true;
            tv.CurrentResolution = new Resolution { Width = 2560, Height = 1440, Frequency = 120 };
            tv.Position = new Point();

            eizo.IsActive = true;
            eizo.CurrentResolution = new Resolution { Width = 1680, Height = 1050, Frequency = 60 };
            eizo.Position = new Point
            {
                X = (int) tv.CurrentResolution.Width,
                Y = (int) (tv.CurrentResolution.Height - eizo.CurrentResolution.Height)
            };

            lc32G7.IsActive = false;
            vg279.IsActive = false;

            Update(monitors);
        }

        private static void SetSetupB(IList<Monitor> monitors)
        {
            var lc32G7 = monitors.First(monitor => monitor.DisplayName.Contains("LC32G7"));
            var vg279 = monitors.First(monitor => monitor.DisplayName == "VG279");
            var tv = monitors.First(monitor => monitor.DisplayName == "SAMSUNG");
            var eizo = monitors.First(monitor => monitor.DisplayName == "S2231W");

            // Setup B
            //lc32G7.IsActive = true;
            //lc32G7.IsPrimary = true;
            //lc32G7.CurrentResolution = new Resolution { Width = 2560, Height = 1440, Frequency = 240 };
            //lc32G7.Position = new Point { X = 0, Y = 0 };
            //Update(lc32G7);

            //lc32G7.IsActive = true;
            lc32G7.CurrentResolution = new Resolution { Width = 1920, Height = 1080, Frequency = 120 };
            //lc32G7.Position = new Point { X = (int) -lc32G7.CurrentResolution.Width, Y = (int) (vg279.CurrentResolution.Height - vg279.CurrentResolution.Height) };

            Update(monitors);
            //eizo.IsActive = false;
            //tv.IsActive = false;
            //Update(tv);
        }
    }
}