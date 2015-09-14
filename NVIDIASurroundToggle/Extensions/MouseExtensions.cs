namespace NVIDIASurroundToggle.Extensions
{
    using System.Windows;

    using TestStack.White.InputDevices;

    public static class MouseExtensions
    {
        private static Point? mouseLastPosition;

        public static void SavePosition(this Mouse m)
        {
            mouseLastPosition = m.Location;
        }

        public static void RestoreLocation(this Mouse m)
        {
            if (mouseLastPosition != null)
            {
                m.Location = mouseLastPosition.Value;
            }
        }
    }
}