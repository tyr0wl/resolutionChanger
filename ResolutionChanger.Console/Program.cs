using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes;
using ResolutionChanger.Win32.DisplaySettings;
using SystemConsole = System.Console;

namespace ResolutionChanger.Console
{
    internal class Program
    {
        public static Dictionary<uint, string> friendlyMonitors = new ();

        private static void Main(string[] args)
        {
            var monitors = GetMonitors();

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
                X = (int)tv.CurrentResolution.Width,
                Y = (int)(tv.CurrentResolution.Height - eizo.CurrentResolution.Height),
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

        public static void Update(IList<Monitor> monitors)
        {
        }

        private static IList<Monitor> GetMonitors()
        {
            var (paths, modes) = DisplayConfigHelper.GetDisplayConfig();

            // gdi, source,target,friendly,devicePath
            var monitors = new Dictionary<string, Monitor>();

            for (var index = 0; index < paths.Length; index++)
            {
                var displayPath = paths[index];

                if (!displayPath.targetInfo.targetAvailable)
                {
                    continue;
                }

                var sourceInfo = displayPath.sourceInfo;
                var targetInfo = displayPath.targetInfo;
                var sourceDeviceName = DisplayConfigHelper.GetGdiDeviceNameFromSource(sourceInfo.adapterId, sourceInfo.id);
                var targetDeviceName = DisplayConfigHelper.GetTargetDeviceName(targetInfo.adapterId, targetInfo.id);
                var adapterName = DisplayConfigHelper.GetAdapterName(targetInfo.adapterId);

                if (displayPath.flags.HasFlag(PathInfoFlags.Active))
                {
                    SystemConsole.WriteLine($"Path flags:{displayPath.flags}");
                    PrintPath(sourceInfo, targetInfo, targetDeviceName, sourceDeviceName);

                    friendlyMonitors.Add(targetInfo.id, targetDeviceName.monitorFriendlyDeviceName);
                    var monitor = DisplayConfigHelper.GetMonitor(displayPath, modes, targetDeviceName);
                    monitors.Add(sourceDeviceName.viewGdiDeviceName, monitor);
                }
                else if (!sourceInfo.statusFlags.HasFlag(SourceInfoFlags.InUse) && !targetInfo.statusFlags.HasFlag(PathTargetInfoFlags.InUse) && !monitors.ContainsKey(sourceDeviceName.viewGdiDeviceName))
                {
                    paths[index].flags |= PathInfoFlags.Active;
                    paths[index].sourceInfo.statusFlags |= SourceInfoFlags.InUse;
                    paths[index].targetInfo.statusFlags |= PathTargetInfoFlags.InUse;
                    paths[index].sourceInfo.modeInfoIdx = PathSourceInfo.ModeIdxInvalid;
                    paths[index].targetInfo.modeInfoIdx = PathTargetInfo.ModeIdxInvalid;
                    var result = DisplayConfigApi.SetDisplayConfig((uint) paths.Length, paths, (uint) modes.Length, modes, SetDisplayConfigFlags.Validate | SetDisplayConfigFlags.UseSuppliedDisplayConfig);

                    if (result != Win32Status.ErrorSuccess)
                    {
                        paths[index].flags &= ~PathInfoFlags.Active;
                        paths[index].sourceInfo.statusFlags &= ~SourceInfoFlags.InUse;
                        paths[index].targetInfo.statusFlags &= ~PathTargetInfoFlags.InUse;
                    }
                    else
                    {
                        friendlyMonitors.Add(targetInfo.id, targetDeviceName.monitorFriendlyDeviceName);
                        var monitor = DisplayConfigHelper.GetMonitor(displayPath, modes, targetDeviceName);
                        monitors.Add(sourceDeviceName.viewGdiDeviceName, monitor);
                    }
                    SystemConsole.WriteLine($"activation: {result}");
                    PrintPath(paths[index].sourceInfo, paths[index].targetInfo, targetDeviceName, sourceDeviceName);
                }
            }

            return monitors.Values.ToList();
        }

        private static void PrintPath(PathSourceInfo sourceInfo, PathTargetInfo targetInfo, TargetDeviceName targetDeviceName, SourceDeviceName sourceDeviceName)
        {
            SystemConsole.WriteLine(
                $"path:{sourceInfo.id}+{targetInfo.id},{sourceInfo.statusFlags}<->{targetInfo.statusFlags}->{targetDeviceName.outputTechnology},{sourceDeviceName.viewGdiDeviceName},{targetDeviceName.monitorFriendlyDeviceName},{targetDeviceName.monitorDevicePath},{targetDeviceName.connectorInstance},{targetDeviceName.edidManufactureId},{targetDeviceName.edidProductCodeId}");
        }
    }
}