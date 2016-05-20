using System;
using System.Threading;
using System.Windows.Automation;
using NVIDIASurroundToggle.Native;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace NVIDIASurroundToggle.Extensions
{
    internal static class UIItemExtensions
    {
        public static T GetChildWindowWithControlId<T>(this UIItem parent, int controlId, int timeout = 0)
            where T : UIItem
        {
            do
            {
                var pointer = IntPtr.Zero;
                Methods.EnumWindowProcedure childProc = (handle, arg) =>
                {
                    var cId = Methods.GetWindowLong(handle, -12);
                    if (cId == controlId)
                    {
                        pointer = handle;
                        return false;
                    }
                    return true;
                };
                Methods.EnumChildWindows(parent.GetHWnd(), childProc, IntPtr.Zero);
                if (pointer != IntPtr.Zero)
                {
                    var el = AutomationElement.FromHandle(pointer);
                    return (T) Activator.CreateInstance(typeof (T), el, new ProcessActionListener(el));
                }
                Thread.Sleep(200);
                timeout -= 200;
            } while (timeout > 0);
            return null;
        }

        public static IntPtr GetHWnd(this UIItem element)
        {
            var nativeHandleNoDefault =
                element.AutomationElement.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty, true);
            return nativeHandleNoDefault == AutomationElement.NotSupported
                ? IntPtr.Zero
                : new IntPtr((int) nativeHandleNoDefault);
        }
    }
}