using System.Windows;
using TestStack.White.InputDevices;

namespace NVIDIASurroundToggle.Extensions
{
    public static class MouseExtensions
    {
        private static Point? _mouseLastPosition;

        public static void SavePosition(this Mouse m)
        {
            _mouseLastPosition = m.Location;
        }

        public static void RestoreLocation(this Mouse m)
        {
            if (_mouseLastPosition != null)
            {
                m.Location = _mouseLastPosition.Value;
            }
        }
    }
}