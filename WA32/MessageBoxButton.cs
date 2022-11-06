namespace WA32;


/// <summary></summary>
public enum MessageBoxButton : uint
{
    /// <summary></summary>
    OK                = 0x00000000,

    /// <summary></summary>
    OKCancel          = 0x00000001,

    /// <summary></summary>
    AbortRetryIgnore  = 0x00000002,

    /// <summary></summary>
    YesNoCancel       = 0x00000003,

    /// <summary></summary>
    YesNo             = 0x00000004,

    /// <summary></summary>
    RetryCancel       = 0x00000005,

    /// <summary></summary>
    CancelTryContinue = 0x00000005,
}
