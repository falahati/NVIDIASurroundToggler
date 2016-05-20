using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    /// <summary>
    ///     This structure contains the coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        /// <summary>
        ///     The horizontal (x) coordinate of the point.
        /// </summary>
        public int X;

        /// <summary>
        ///     The vertical (y) coordinate of the point.
        /// </summary>
        public int Y;
    }
}