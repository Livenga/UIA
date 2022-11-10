namespace UIA.ConsoleApp;

using WA32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Automation.Provider;


/// <summary></summary>
internal class Program
{
    private static string WindowName = "UIA Example Window";

    /// <summary></summary>
    static void Main(string[] args)
    {
        WA32.HWindow? hWindow = null;
        try
        {
            var windows = WA32
                .HWindow
                .FindAll();
#if DEBUG
            foreach(var _hWindow in windows)
            {
                Debug.WriteLine($"DEBUG | {_hWindow.ProcessId} {_hWindow.Text}\t{_hWindow.ModuleFile}");
            }
#endif
            hWindow = windows.FirstOrDefault(h => h.Text == WindowName);
        }
        catch(Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
#endif
        }

        if(hWindow == null)
        {
            var ret = WA32.User32.Wrap.MessageBoxShow(
                    icon:    WA32.MessageBoxIcon.Error,
                    button:  WA32.MessageBoxButton.OK,
                    caption: "エラー",
                    text:    $"該当 Window({WindowName}) が見つかりませんでした.");

#if DEBUG
            Debug.WriteLine(ret);
#endif
            return;
        }

        User32.EnumWindows(OnEnumWindows, IntPtr.Zero);
        Console.Error.WriteLine($"{hWindow.Text}");

        //
        User32.EnumChildWindows(hWindow.Handle, OnEnumChildWindows, IntPtr.Zero);


        Console.ReadLine();
        Console.Error.WriteLine($"Please Any keys...");
    }


    /// <summary></summary>
    private static bool OnEnumChildWindows(IntPtr hWnd, IntPtr lParam)
    {
        //Console.Error.WriteLine($"{hWnd.ToInt32():X} {User32.Wrap.TryGetWindowText(hWnd)} {User32.Wrap.TryGetClassName(hWnd)}");
        return true;
    }

    /// <summary></summary>
    private static bool OnEnumWindows(IntPtr hWnd, IntPtr lParam)
    {
        int processId = 0;
        User32.GetWindowThreadProcessId(hWnd, out processId);

        if(processId != 0)
        {
            IntPtr hModules = IntPtr.Zero, hCbNeeded = IntPtr.Zero;

            try
            {
                hModules = Marshal.AllocCoTaskMem(cb: 32 * Marshal.SizeOf<IntPtr>());
                hCbNeeded = Marshal.AllocCoTaskMem(cb: Marshal.SizeOf<int>());

                var ret = Kernel32.EnumProcessModulesEx(
                        Process.GetCurrentProcess().Handle,
                        hModules,
                        32,
                        hCbNeeded,
                        3);
                if(ret)
                {
                    foreach(var hModule in Enumerable.Range(0, 32)
                            .Select(idx => Marshal.ReadIntPtr(hModules, idx)))
                    {
                        Console.Error.WriteLine($"DEBUG | MODULE {hModule.ToInt64():X}");
                    }
                }
                else
                {
                    throw new System.ComponentModel.Win32Exception(Kernel32.GetLastError());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                if(hModules != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(hModules);
                }
                if(hCbNeeded != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(hCbNeeded);
                }
            }
        }

        return true;
    }
}
