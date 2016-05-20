using System;
using System.IO;
using System.Threading;
using IWshRuntimeLibrary;
using NVIDIASurroundToggle.Native;
using NVIDIASurroundToggle.Native.Enums;
using File = System.IO.File;

namespace NVIDIASurroundToggle
{
    internal static class Utility
    {
        public delegate bool ReoccurringMethod();

        public static Exception ContinueException(Action code)
        {
            if (code != null)
            {
                try
                {
                    code();
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
            return null;
        }

        public static bool DoTimeout(ReoccurringMethod action, int timeout = 5000, int interval = 100)
        {
            var time = 0;
            do
            {
                var value = action();
                if (value)
                {
                    return true;
                }
                Thread.Sleep(interval);
                time += interval;
            } while (time < timeout);
            return false;
        }

        public static bool CreateShortcut(
            string address,
            string filename,
            string arguments = "",
            string iconfile = null,
            string description = "")
        {
            address = Path.ChangeExtension(address, @"lnk");
            try
            {
                if (File.Exists(address)) // Remove the old file to replace it
                {
                    File.Delete(address);
                }
                var shortcut = (IWshShortcut) new WshShell().CreateShortcut(address);
                shortcut.Description = description;
                shortcut.TargetPath = filename;
                shortcut.Arguments = arguments;
                shortcut.WorkingDirectory = Path.GetDirectoryName(filename) ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(iconfile))
                {
                    shortcut.IconLocation = iconfile;
                }
                shortcut.Save();
                return File.Exists(address);
            }
            catch
            {
                if (File.Exists(address)) // Clean up a failed attempt
                {
                    File.Delete(address);
                }
            }
            return false;
        }

        public static T DefaultOnException<T>(Func<T> code, T defaultValue = default(T))
        {
            var result = defaultValue;
            if (code != null)
            {
                try
                {
                    result = code();
                }
                catch
                {
                    // ignored
                }
            }
            return result;
        }

        public static int TryParseIntOrDefault(this string input, int defaultValue = 0)
        {
            int value;
            return int.TryParse(input, out value) ? value : defaultValue;
        }

        public static void ToggleTaskbar(bool show)
        {
            var hwnd = Methods.FindWindow(@"Shell_TrayWnd", "");
            if (hwnd != IntPtr.Zero)
            {
                Methods.ShowWindow(hwnd, show ? ShowWindow.ShowNormal : ShowWindow.Hide);
            }
        }
    }
}