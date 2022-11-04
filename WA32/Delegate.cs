namespace WA32;

using System;
using System.Text;
using System.Runtime.InteropServices;


/// <summary></summary>
public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

/// <summary></summary>
public delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

/// <summary></summary>
public delegate bool EnumPropsExProc(IntPtr hWnd, IntPtr lpszString, IntPtr hData, IntPtr dwData);
