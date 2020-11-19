using System;

namespace ResolutionChanger.Unmanaged.DisplaySettings
{
    [Flags]
    public enum DmFieldFlags
    {
        /// <summary>
        ///     DM_ORIENTATION
        /// </summary>
        Orientation = 0x1,

        /// <summary>
        ///     DM_PAPERSIZE
        /// </summary>
        PaperSize = 0x2,

        /// <summary>
        ///     DM_PAPERLENGTH
        /// </summary>
        PaperLength = 0x4,

        /// <summary>
        ///     DM_PAPERWIDTH
        /// </summary>
        PaperWidth = 0x8,

        /// <summary>
        ///     DM_SCALE
        /// </summary>
        Scale = 0x10,

        /// <summary>
        ///     DM_POSITION
        /// </summary>
        Position = 0x20,

        /// <summary>
        ///     DM_NUP
        /// </summary>
        NUP = 0x40,

        /// <summary>
        ///     DM_DISPLAYORIENTATION 
        /// </summary>
        DisplayOrientation = 0x80,

        /// <summary>
        ///     DM_COPIES
        /// </summary>
        Copies = 0x100,

        /// <summary>
        ///     DM_DEFAULTSOURCE
        /// </summary>
        DefaultSource = 0x200,

        /// <summary>
        ///     DM_PRINTQUALITY
        /// </summary>
        PrintQuality = 0x400,

        /// <summary>
        ///     DM_COLOR
        /// </summary>
        Color = 0x800,

        /// <summary>
        ///     DM_DUPLEX
        /// </summary>
        Duplex = 0x1000,

        /// <summary>
        ///     DM_YRESOLUTION
        /// </summary>
        YResolution = 0x2000,

        /// <summary>
        ///     DM_TTOPTION
        /// </summary>
        TtOption = 0x4000,

        /// <summary>
        ///     DM_COLLATE
        /// </summary>
        Collate = 0x8000,

        /// <summary>
        ///     DM_FORMNAME
        /// </summary>
        FormName = 0x10000,

        /// <summary>
        ///     DM_LOGPIXELS
        /// </summary>
        LogPixels = 0x20000,

        /// <summary>
        ///     DM_BITSPERPEL
        /// </summary>
        BitsPerPixel = 0x40000,

        /// <summary>
        ///     DM_PELSWIDTH
        /// </summary>
        PelsWidth = 0x80000,

        /// <summary>
        ///     DM_PELSHEIGHT
        /// </summary>
        PelsHeight = 0x100000,

        /// <summary>
        ///     DM_DISPLAYFLAGS
        /// </summary>
        DisplayFlags = 0x200000,

        /// <summary>
        ///     DM_DISPLAYFREQUENCY
        /// </summary>
        DisplayFrequency = 0x400000,

        /// <summary>
        ///     DM_ICMMETHOD
        /// </summary>
        IcmMethod = 0x800000,

        /// <summary>
        ///     DM_ICMINTENT
        /// </summary>
        IcmIntent = 0x1000000,

        /// <summary>
        ///     DM_MEDIATYPE
        /// </summary>
        MediaType = 0x2000000,

        /// <summary>
        ///     DM_DITHERTYPE
        /// </summary>
        DitherType = 0x4000000,

        /// <summary>
        ///     DM_PANNINGWIDTH
        /// </summary>
        PanningWidth = 0x8000000,

        /// <summary>
        ///     DM_PANNINGHEIGHT
        /// </summary>
        PanningHeight = 0x10000000,

        /// <summary>
        ///     DM_DISPLAYFIXEDOUTPUT 
        /// </summary>
        DisplayFixedOutput = 0x20000000
    }
}
