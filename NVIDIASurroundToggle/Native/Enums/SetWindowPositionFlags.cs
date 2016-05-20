using System;

namespace NVIDIASurroundToggle.Native.Enums
{
    [Flags]
    internal enum SetWindowPositionFlags : uint
    {
        AsynchronousWindowPosition = 0x4000,

        DeferErase = 0x2000,

        DrawFrame = 0x0020,

        FrameChanged = 0x0020,

        HideWindow = 0x0080,

        DoNotActivate = 0x0010,

        DoNotCopyBits = 0x0100,

        IgnoreMove = 0x0002,

        DoNotChangeOwnerZOrder = 0x0200,

        DoNotRedraw = 0x0008,

        DoNotReposition = 0x0200,

        DoNotSendChangingEvent = 0x0400,

        IgnoreResize = 0x0001,

        IgnoreZOrder = 0x0004,

        ShowWindow = 0x0040
    }
}