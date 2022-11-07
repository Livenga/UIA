namespace WA32.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using WA32;
using Xunit;
using Xunit.Abstractions;


/// <summary></summary>
public class User32Test
{
    private readonly ITestOutputHelper _outputHelper;

    /// <summary></summary>
    public User32Test(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }


    /// <summary></summary>
    [Fact]
    public void EnumChildWindows()
    {
        WA32.User32.EnumWindows(OnEnumWindowProc, IntPtr.Zero);
    }

    /// <summary></summary>
    private bool OnEnumPropsExProc(IntPtr hWnd, IntPtr lpString, IntPtr hData, IntPtr lParam)
    {
        try
        {
            _outputHelper.WriteLine($"\t{Marshal.PtrToStringUni(lpString) ?? string.Empty} {hData}");
        } catch { }

        return true;
    }

    /// <summary></summary>
    private bool OnEnumWindowProc(IntPtr hWnd, IntPtr lParam)
    {
        var window = User32.Wrap.GetWindowText(hWnd) ?? string.Empty;
        var className = User32.Wrap.GetClassName(hWnd) ?? string.Empty;
        _outputHelper.WriteLine($"0x{hWnd.ToInt32():X} {window}\t{className}");

        WA32.User32.EnumChildWindows(hWnd, OnEnumChildProc, IntPtr.Zero);
        WA32.User32.EnumPropsEx(hWnd, OnEnumPropsExProc, IntPtr.Zero);

        return true;
    }

    /// <summary></summary>
    private bool OnEnumChildProc(IntPtr hWnd, IntPtr lParam)
    {
        var window = User32.Wrap.GetWindowText(hWnd) ?? string.Empty;
        var className = User32.Wrap.GetClassName(hWnd) ?? string.Empty;

        _outputHelper.WriteLine($"\tChild: 0x{hWnd.ToInt32():X}:{WA32.User32.GetParent(hWnd):X} {window}\t{className}");
        WA32.User32.EnumPropsEx(hWnd, OnEnumPropsExProc, IntPtr.Zero);

        WA32.User32.EnumChildWindows(hWnd, OnEnumChildProc, IntPtr.Zero);

        return true;
    }
}
