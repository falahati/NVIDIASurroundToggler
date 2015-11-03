using System;
using System.Runtime.InteropServices;
using NVIDIASurroundToggle.Native.Enums;
using NVIDIASurroundToggle.Native.Stractures;

namespace NVIDIASurroundToggle.Native
{
    public static class Methods
    {
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        public delegate bool MonitorEnumDelegate(
            IntPtr monitorHandle,
            IntPtr hdcMonitor,
            ref Rect lprcMonitor,
            IntPtr dwData);

        [DllImport("user32")]
        public static extern bool RedrawWindow(
            IntPtr hWnd,
            IntPtr lprcUpdate,
            IntPtr hrgnUpdate,
            RedrawWindowFlags flags);

        [DllImport("user32")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32", SetLastError = true)]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags);

        [DllImport("user32")]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32")]
        public static extern IntPtr FindWindow(string className, string windowText);

        [DllImport("user32")]
        public static extern int ShowWindow(IntPtr hwnd, ShowWindow status);

        [DllImport("user32")]
        public static extern bool EnumDisplaySettings(
            string deviceName,
            DisplaySettingsMode modeNum,
            ref DevMode devMode);

        [DllImport("user32")]
        public static extern ChangeDisplaySettingsExResults ChangeDisplaySettingsEx(
            string lpszDeviceName,
            ref DevMode lpDevMode,
            IntPtr hwnd,
            ChangeDisplaySettingsFlags dwflags,
            IntPtr lParam);

        [DllImport("user32")]
        public static extern ChangeDisplaySettingsExResults ChangeDisplaySettingsEx(
            string lpszDeviceName,
            IntPtr lpDevMode,
            IntPtr hwnd,
            ChangeDisplaySettingsFlags dwflags,
            IntPtr lParam);

        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, [Out] int wParam, string lParam);

        [DllImport("user32", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32")]
        public static extern bool EnumDisplayMonitors(
            IntPtr hdc,
            IntPtr lprcClip,
            MonitorEnumDelegate lpfnEnum,
            IntPtr dwData);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx lpmi);
    }
}