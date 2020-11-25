namespace ResolutionChanger.Win32.DisplayConfig.Modes
{
    /// <summary>
    ///     The D3DKMDT_VIDEO_SIGNAL_STANDARD enumeration contains constants that represent video signal standards.
    ///     D3DKMDT_VIDEO_SIGNAL_STANDARD enumeration (d3dkmdt.h)
    /// </summary>
    public enum VideoSignalStandard : ushort
    {
        /// <summary>
        ///     Indicates that a variable of type D3DKMDT_VIDEO_SIGNAL_STANDARD has not yet been assigned a meaningful value.
        ///     D3DKMDT_VSS_UNINITIALIZED
        /// </summary>
        Uninitialized = 0,

        /// <summary>
        ///     Represents the Video Electronics Standards Association (VESA) Display Monitor Timing (DMT) standard.
        ///     D3DKMDT_VSS_VESA_DMT
        /// </summary>
        VesaDmt = 1,

        /// <summary>
        ///     Represents the VESA Generalized Timing Formula (GTF) standard.
        ///     D3DKMDT_VSS_VESA_GTF
        /// </summary>
        VesaGtf = 2,

        /// <summary>
        ///     Represents the VESA Coordinated Video Timing (CVT) standard.
        ///     D3DKMDT_VSS_VESA_CVT
        /// </summary>
        VesaCvt = 3,

        /// <summary>
        ///     Represents the IBM standard.
        ///     D3DKMDT_VSS_IBM
        /// </summary>
        Ibm = 4,

        /// <summary>
        ///     Represents the Apple standard.
        ///     D3DKMDT_VSS_APPLE
        /// </summary>
        Apple = 5,

        /// <summary>
        ///     Represents the National Television Standards Committee (NTSC) standard.
        ///     D3DKMDT_VSS_NTSC_M
        /// </summary>
        NtscM = 6,

        /// <summary>
        ///     Represents the NTSC standard.
        ///     D3DKMDT_VSS_NTSC_J
        /// </summary>
        NtscJ = 7,

        /// <summary>
        ///     Represents the NTSC standard.
        ///     D3DKMDT_VSS_NTSC_443
        /// </summary>
        Ntsc443 = 8,

        /// <summary>
        ///     Represents the Phase Alteration Line (PAL) standard.
        ///     D3DKMDT_VSS_PAL_B
        /// </summary>
        PalB = 9,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_B1
        /// </summary>
        PalB1 = 10,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_G
        /// </summary>
        PalG = 11,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_H
        /// </summary>
        PalH = 12,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_I
        /// </summary>
        PalI = 13,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_D
        PalD = 14,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_N
        /// </summary>
        PalN = 15,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_NC
        /// </summary>
        PalNc = 16,

        /// <summary>
        ///     Represents the Systeme Electronic Pour Couleur Avec Memoire (SECAM) standard.
        ///     D3DKMDT_VSS_SECAM_B
        /// </summary>
        SecamB = 17,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_D
        /// </summary>
        SecamD = 18,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_G
        /// </summary>
        SecamG = 19,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_H
        /// </summary>
        SecamH = 20,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_K
        /// </summary>
        SecamK = 21,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_K1
        /// </summary>
        SecamK1 = 22,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_L
        /// </summary>
        SecamL = 23,

        /// <summary>
        ///     Represents the SECAM standard.
        ///     D3DKMDT_VSS_SECAM_L1
        /// </summary>
        SecamL1 = 24,

        /// <summary>
        ///     Represents the Electronics Industries Association (EIA) standard.
        ///     D3DKMDT_VSS_EIA_861
        /// </summary>
        Eia861 = 25,

        /// <summary>
        ///     Represents the EIA standard.
        ///     D3DKMDT_VSS_EIA_861A
        /// </summary>
        Eia861A = 26,

        /// <summary>
        ///     Represents the EIA standard.
        ///     D3DKMDT_VSS_EIA_861B
        /// </summary>
        Eia861B = 27,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_K
        /// </summary>
        PalK = 28,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_K1
        /// </summary>
        PalK1 = 29,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_L
        /// </summary>
        PalL = 30,

        /// <summary>
        ///     Represents the PAL standard.
        ///     D3DKMDT_VSS_PAL_M
        /// </summary>
        PalM = 31,

        /// <summary>
        ///     Represents any video standard other than those represented by the previous constants in this enumeration.
        ///     D3DKMDT_VSS_OTHER
        /// </summary>
        Other = 255
    }
}