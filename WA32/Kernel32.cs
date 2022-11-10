namespace WA32;

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;


/// <summary></summary>
public static class Kernel32
{
    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetLastError();

    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, Int32 dwProcessId);

    /// <summary></summary>
    [DllImport("psapi.dll", EntryPoint = "EnumProcessModulesEx", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumProcessModulesEx(
            IntPtr hProcess,
            [Out]IntPtr lphModule,
            int cb,
            [Out]IntPtr lpcbNeeded,
            int dwFilterFlag);

    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool CloseHandle(IntPtr hObject);

    /// <summary></summary>
    [DllImport("psapi.dll", EntryPoint = "GetModuleFileNameExW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetModuleFileNameEx(
            IntPtr hProcess,
            IntPtr hModule,
            [Out]StringBuilder lpFileName,
            int nSize);

    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "SetDllDirectoryW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool SetDllDirectory(string lpPathName);

    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "LoadLibraryW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadLibrary(string lpLibFileName);

    /// <summary></summary>
    [DllImport("kernel32.dll", EntryPoint = "FreeLibrary", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool FreeLibrary(IntPtr hLibModule);


    /// <summary></summary>
    public static void ThrowWin32Exception()
    {
        var errorCode = GetLastError();
        if(errorCode != 0)
        {
                throw new Win32Exception(errorCode);
        }
    }
}
