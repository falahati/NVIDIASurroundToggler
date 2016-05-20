using System;

namespace NVIDIASurroundToggle.Native.Enums
{
    [Flags]
    internal enum RedrawWindowFlags : uint
    {
        Invalidate = 0x1,

        InternalPaint = 0x2,

        Erase = 0x4,

        Validate = 0x8,

        NoInternalPaint = 0x10,

        NoErase = 0x20,

        NoChildren = 0x40,

        AllChildren = 0x80,

        UpdateNow = 0x100,

        EraseNow = 0x200,

        Frame = 0x400,

        NoFrame = 0x800
    }
}