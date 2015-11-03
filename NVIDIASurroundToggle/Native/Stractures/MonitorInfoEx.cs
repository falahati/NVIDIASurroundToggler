using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfoEx
    {
        public int Size;

        public Rect Monitor;

        public Rect WorkArea;

        public uint Flags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string DeviceName;

        public MonitorInfoEx Init()
        {
            DeviceName = string.Empty;
            Size = Marshal.SizeOf(this);
            return this;
        }
    }
}