﻿namespace WA32;

using System;
using System.Runtime.InteropServices;
using System.Text;


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

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetClassNameW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetClassName(
            IntPtr hWnd,
            [Out]StringBuilder lpClassName,
            int nMaxCount);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumChildWindows", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumPropsExW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int EnumPropsEx(IntPtr hWnd, EnumPropsExProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);


    /// <summary></summary>
    public static class Wrap
    {
        /// <summary>
        /// </summary>
        public static string? GetWindowText(IntPtr hWnd)
        {
            var length = User32.GetWindowTextLength(hWnd);
            if(length == 0)
            {
                Kernel32.ThrowWin32Exception();
                return null;
            }

            var sb = new StringBuilder(length + 1);
            var ret = User32.GetWindowText(hWnd, sb, length + 1);
            if(ret == 0)
            {
                Kernel32.ThrowWin32Exception();
            }

            return sb.ToString();
        }

        /// <summary>
        /// </summary>
        public static string? GetClassName(
                IntPtr hWnd,
                int length = 2048)
        {
            var sb = new StringBuilder(length);
            var ret = User32.GetClassName(hWnd, sb, length);

            if(ret == 0)
            {
                Kernel32.ThrowWin32Exception();
                return null;
            }

            return sb.ToString(0, ret);
        }
    }
}
