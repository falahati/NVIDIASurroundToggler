namespace NVIDIASurroundToggle.Native.Stractures
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct DevMode
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        [FieldOffset(0)]
        public string DeviceName;

        [FieldOffset(32)]
        public short SpecVersion;

        [FieldOffset(34)]
        public short DriverVersion;

        [FieldOffset(36)]
        public short Size;

        [FieldOffset(38)]
        public short DriverExtra;

        [FieldOffset(40)]
        public DevModeFields Fields;

        [FieldOffset(44)]
        public Point Position;

        [FieldOffset(52)]
        public int DisplayOrientation;

        [FieldOffset(56)]
        public int DisplayFixedOutput;

        [FieldOffset(60)]
        public ColorSpace Color;

        [FieldOffset(62)]
        public DuplexMode Duplex;

        [FieldOffset(64)]
        public short YResolution;

        [FieldOffset(66)]
        public short TTOption;

        [FieldOffset(68)]
        public CollateStatus Collate;

        [FieldOffset(72)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FormName;

        [FieldOffset(102)]
        public short LogPixels;

        [FieldOffset(104)]
        public int BitsPerPel;

        [FieldOffset(108)]
        public int PelsWidth;

        [FieldOffset(112)]
        public int PelsHeight;

        [FieldOffset(116)]
        public int DisplayFlags;

        [FieldOffset(116)]
        public int Nup;

        [FieldOffset(120)]
        public int DisplayFrequency;

        public DevMode Init()
        {
            this.Size = (short)Marshal.SizeOf(this);
            return this;
        }

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

        public enum DuplexMode : short
        {
            Unknown = 0,

            Simplex = 1,

            Vertical = 2,

            Horizontal = 3
        }

        public enum CollateStatus : short
        {
            Off = 0,

            On = 1
        }

        public enum ColorSpace : short
        {
            Unknown = 0,

            Monochrome = 1,

            Color = 2
        }

        public static DevMode GetEmpty()
        {
            return
                new DevMode
                    {
                        DriverExtra = 0,
                        Fields = DevModeFields.Position | DevModeFields.PelsHeight | DevModeFields.PelsWidth,
                        PelsHeight = 0,
                        PelsWidth = 0,
                        Position = new Point { X = 0, Y = 0 }
                    }.Init();
        }
    }
}