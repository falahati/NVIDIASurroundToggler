namespace NVIDIASurroundToggle.Native.Enums
{
    using System;

    [Flags]
    public enum ChangeDisplaySettingsFlags : uint
    {
        Updateregistry = 0x00000001,

        Global = 0x00000008,

        SetPrimary = 0x00000010,

        Reset = 0x40000000,

        Noreset = 0x10000000
    }
}