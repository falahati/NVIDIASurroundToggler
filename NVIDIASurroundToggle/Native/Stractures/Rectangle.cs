using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rectangle
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }
}