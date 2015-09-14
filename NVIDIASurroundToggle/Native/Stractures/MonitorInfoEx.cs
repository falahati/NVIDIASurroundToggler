namespace NVIDIASurroundToggle.Native.Stractures
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfoEx
    {
        public int Size;

        public Rect Monitor;

        public Rect WorkArea;

        public uint Flags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;

        public MonitorInfoEx Init()
        {
            this.DeviceName = string.Empty;
            this.Size = Marshal.SizeOf(this);
            return this;
        }
    }
}