using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }
}