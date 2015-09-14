namespace NVIDIASurroundToggle.Extensions
{
    using System;

    using NVIDIASurroundToggle.Native;
    using NVIDIASurroundToggle.Native.Enums;

    using TestStack.White.UIItems.WindowItems;

    public static class WindowExtensions
    {
        public static void HideMinimize(this Window window)
        {
            int posX = Methods.GetSystemMetrics(SystemMetric.XVirtualScreen);
            int posY = Methods.GetSystemMetrics(SystemMetric.YVirtualScreen);
            int sizeX = Methods.GetSystemMetrics(SystemMetric.WidthVirtualScreen);
            int sizeY = Methods.GetSystemMetrics(SystemMetric.HeightVirtualScreen);
            IntPtr handle = window.GetHWnd();
            var style = (WindowStyles)Methods.GetWindowLong(handle, -0x14);
            var isResizableAndNotModal = (style.HasFlag(WindowStyles.ThickFrame)
                                          || style.HasFlag(WindowStyles.WindowEdge)
                                          && !style.HasFlag(WindowStyles.DlgModalFrame));

            Methods.SetWindowLong(handle, -20, Methods.GetWindowLong(handle, -20) ^ 0x80000);
            Methods.SetLayeredWindowAttributes(handle, 0, 1, 0x2);
            Methods.ShowWindow(handle, ShowWindow.Hide);
            Methods.SetWindowLong(
                handle,
                -0x14,
                (uint)((style | WindowStyles.ToolWindow) & ~(WindowStyles.ThickFrame) & ~(WindowStyles.WindowEdge)));
            Methods.SetWindowPos(
                handle,
                new IntPtr(1),
                posX,
                posY,
                sizeX,
                sizeY,
                isResizableAndNotModal
                    ? SetWindowPosFlags.HideWindow
                    : SetWindowPosFlags.HideWindow | SetWindowPosFlags.IgnoreResize);
        }

        public static void ShowFocus(this Window window)
        {
            int posX = Methods.GetSystemMetrics(SystemMetric.XVirtualScreen);
            int posY = Methods.GetSystemMetrics(SystemMetric.YVirtualScreen);
            int sizeX = Methods.GetSystemMetrics(SystemMetric.WidthVirtualScreen);
            int sizeY = Methods.GetSystemMetrics(SystemMetric.HeightVirtualScreen);
            IntPtr handle = window.GetHWnd();
            Methods.ShowWindow(handle, ShowWindow.ShowNormal);
            Methods.SetWindowPos(
                handle,
                new IntPtr(-1),
                posX,
                posY,
                sizeX,
                sizeY,
                SetWindowPosFlags.ShowWindow | SetWindowPosFlags.IgnoreResize);
            window.Focus();
            Methods.SetWindowLong(handle, -20, Methods.GetWindowLong(handle, -20) ^ 0x80000);
            Methods.SetLayeredWindowAttributes(handle, 0, 1, 0x2);
        }

        public static void ShowTopMost(this Window window)
        {
            int posX = (int)((Methods.GetSystemMetrics(SystemMetric.WidthVirtualScreen) - window.Bounds.Width) / 2)
                       + Methods.GetSystemMetrics(SystemMetric.XVirtualScreen);
            int posY = (int)((Methods.GetSystemMetrics(SystemMetric.HeightVirtualScreen) - window.Bounds.Height) / 2)
                       + Methods.GetSystemMetrics(SystemMetric.YVirtualScreen);

            IntPtr handle = window.GetHWnd();
            Methods.ShowWindow(handle, ShowWindow.ShowNormal);
            Methods.SetWindowLong(handle, -20, Methods.GetWindowLong(handle, -20) ^ 0x80000);
            Methods.SetLayeredWindowAttributes(handle, 0, 255, 0x2);
            Methods.SetWindowPos(
                handle,
                new IntPtr(-1),
                posX,
                posY,
                0,
                0,
                SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.ShowWindow | SetWindowPosFlags.FrameChanged);
            window.Focus();
            Methods.RedrawWindow(
                handle,
                IntPtr.Zero,
                IntPtr.Zero,
                RedrawWindowFlags.Invalidate | RedrawWindowFlags.UpdateNow | RedrawWindowFlags.AllChildren);
        }

        public static void ExecuteAutomationAction(this Window window, Action code)
        {
            window.ExecuteAutomationAction(
                () =>
                    {
                        code();
                        return false;
                    });
        }

        public static T ExecuteAutomationAction<T>(this Window window, Func<T> code)
        {
            window.WaitWhileBusy();
            window.ShowFocus();
            var result = code();
            window.HideMinimize();
            window.WaitWhileBusy();
            return result;
        }
    }
}