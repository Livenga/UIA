namespace WA32;

using System;
using System.Runtime.InteropServices;
using System.Text;


/// <summary></summary>
public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

/// <summary></summary>
public class User32
{
    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowTextW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowText(IntPtr hWnd, [Out]StringBuilder lpString, int nMaxCount);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool IsWindow(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
}
