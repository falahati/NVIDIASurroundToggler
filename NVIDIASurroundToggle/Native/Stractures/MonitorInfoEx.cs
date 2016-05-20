using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct MonitorInfoEx
    {
        public int Size;

        public Rectangle Monitor;

        public Rectangle WorkArea;

        public uint Flags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string DeviceName;

        public MonitorInfoEx Initialize()
        {
            DeviceName = string.Empty;
            Size = Marshal.SizeOf(this);
            return this;
        }
    }
}