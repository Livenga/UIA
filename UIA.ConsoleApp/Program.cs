namespace UIA.ConsoleApp;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        Console.Error.WriteLine($"{hWindow.Text}");

        //
        var aeWindow = AutomationElement.FromHandle(hWindow.Handle);
        UIA.ConsoleApp.Obj.PrintProperties(aeWindow);
    }
}
