namespace WA32;

 using System;
 using System.Runtime.InteropServices;

/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}
