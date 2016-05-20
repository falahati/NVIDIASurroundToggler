using System;
using System.Runtime.InteropServices;

namespace NVIDIASurroundToggle.Native.Stractures
{
    /// <summary>
    ///     Contains information about the initialization and environment of a
    ///     printer or a display device.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct DevMode
    {
        /// <summary>
        ///     Friendly name of the printer or display. This string is unique among device drivers
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] [FieldOffset(0)] public string DeviceName;

        /// <summary>
        ///     The version number of the initialization data specification on which the structure is based.
        /// </summary>
        [FieldOffset(32)] public short SpecificationVersion;

        /// <summary>
        ///     The driver version number assigned by the driver developer.
        /// </summary>
        [FieldOffset(34)] public short DriverVersion;

        /// <summary>
        ///     Specifies the size, in bytes, of the structure, not including any private driver-specific data that might follow
        ///     the structure's public members.
        /// </summary>
        [FieldOffset(36)] public short Size;

        /// <summary>
        ///     Contains the number of bytes of private driver-data that follow this structure.
        /// </summary>
        [FieldOffset(38)] public short DriverExtra;

        /// <summary>
        ///     Specifies whether certain members of the structure have been initialized.
        /// </summary>
        [FieldOffset(40)] public DevModeFields Fields;

        /// <summary>
        ///     Indicates the positional coordinates of the display device in reference to the desktop area. The primary display
        ///     device is always located at coordinates (0, 0).
        /// </summary>
        [FieldOffset(44)] public Point Position;

        /// <summary>
        ///     The orientation at which images should be presented.
        /// </summary>
        [FieldOffset(52)] public int DisplayOrientation;

        /// <summary>
        ///     Indicates how the display presents a low-resolution mode on a higher-resolution display.
        /// </summary>
        [FieldOffset(56)] public int DisplayFixedOutput;

        /// <summary>
        ///     Switches between color and monochrome on color printers.
        /// </summary>
        [FieldOffset(60)] public ColorSpace Color;

        /// <summary>
        ///     Selects duplex or double-sided printing for printers capable of duplex printing.
        /// </summary>
        [FieldOffset(62)] public DuplexMode Duplex;

        /// <summary>
        ///     Specifies the y-resolution, in dots per inch, of the printer.
        /// </summary>
        [FieldOffset(64)] public short YResolution;

        /// <summary>
        ///     Specifies how TrueType fonts should be printed.
        /// </summary>
        [FieldOffset(66)] public short TrueTypeOption;

        /// <summary>
        ///     Specifies whether collation should be used when printing multiple copies.
        /// </summary>
        [FieldOffset(68)] public CollateStatus Collate;

        /// <summary>
        ///     Specifies the name of the form to use; for example, "Letter" or "Legal".
        /// </summary>
        [FieldOffset(72)] [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string FormName;

        /// <summary>
        ///     The number of pixels per logical inch. Printer drivers do not use this member.
        /// </summary>
        [FieldOffset(102)] public short LogicalInchPixels;

        /// <summary>
        ///     Specifies the color resolution, in bits per pixel, of the display device.
        /// </summary>
        [FieldOffset(104)] public int BitsPerPixel;

        /// <summary>
        ///     Specifies the width, in pixels, of the visible device surface.
        /// </summary>
        [FieldOffset(108)] public int PixelsWidth;

        /// <summary>
        ///     Specifies the height, in pixels, of the visible device surface.
        /// </summary>
        [FieldOffset(112)] public int PixelsHeight;

        /// <summary>
        ///     Specifies the device's display mode.
        /// </summary>
        [FieldOffset(116)] public int DisplayFlags;

        /// <summary>
        ///     Specifies where the NUP is done.
        /// </summary>
        [FieldOffset(116)] public int NUP;

        /// <summary>
        ///     Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode. This value is
        ///     also known as the display device's vertical refresh rate.
        /// </summary>
        [FieldOffset(120)] public int DisplayFrequency;

        internal DevMode Initialize()
        {
            Size = (short) Marshal.SizeOf(this);
            return this;
        }


        /// <summary>
        ///     Contains a list of all DevMode fields
        /// </summary>
        [Flags]
        public enum DevModeFields
        {
            Orientation = 0x1,

            PaperSize = 0x2,

            PaperLength = 0x4,

            PaperWidth = 0x8,

            Scale = 0x10,

            Position = 0x20,

            Nup = 0x40,

            DisplayOrientation = 0x80,

            Copies = 0x100,

            DefaultSource = 0x200,

            PrintQuality = 0x400,

            Color = 0x800,

            Duplex = 0x1000,

            YResolution = 0x2000,

            TtOption = 0x4000,

            Collate = 0x8000,

            FormName = 0x10000,

            LogPixels = 0x20000,

            BitsPerPixel = 0x40000,

            PelsWidth = 0x80000,

            PelsHeight = 0x100000,

            DisplayFlags = 0x200000,

            DisplayFrequency = 0x400000,

            IcmMethod = 0x800000,

            IcmIntent = 0x1000000,

            MediaType = 0x2000000,

            DitherType = 0x4000000,

            PanningWidth = 0x8000000,

            PanningHeight = 0x10000000,

            DisplayFixedOutput = 0x20000000
        }

        /// <summary>
        ///     Contains possible values for the Duplex field
        /// </summary>
        public enum DuplexMode : short
        {
            Unknown = 0,

            Simplex = 1,

            Vertical = 2,

            Horizontal = 3
        }

        /// <summary>
        ///     Contains possible values for the Collate field
        /// </summary>
        public enum CollateStatus : short
        {
            Off = 0,

            On = 1
        }

        /// <summary>
        ///     Contains possible values for the Color field
        /// </summary>
        public enum ColorSpace : short
        {
            Unknown = 0,

            Monochrome = 1,

            Color = 2
        }

        internal static DevMode GetEmpty()
        {
            return
                new DevMode
                {
                    DriverExtra = 0,
                    Fields = DevModeFields.Position | DevModeFields.PelsHeight | DevModeFields.PelsWidth,
                    PixelsHeight = 0,
                    PixelsWidth = 0,
                    Position = new Point {X = 0, Y = 0}
                }.Initialize();
        }
    }
}