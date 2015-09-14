namespace NVIDIASurroundToggle.Native.Stractures
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }
}