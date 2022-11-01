namespace UIA.ConsoleApp;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
internal class Program
{
    /// <summary></summary>
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            return;
        }

        var hWindows = WA32.HWindow.FindAll();
        /*Debug.WriteLine(
                String.Join(
                    ", ",
                    hWindows
                        .Where(hWindow => ! string.IsNullOrEmpty(hWindow.Text))
                        .Select(hWindow => hWindow.Text)));*/

        var hWindow = hWindows.FirstOrDefault(hWindow => hWindow.Text == args[0]);
        if(hWindow == null)
        {
            return;
        }

        Debug.WriteLine($"{hWindow.ProcessId} {hWindow.Text}");
        var automationElement = AutomationElement.FromHandle(hWindow.Handle);

        UIA.ConsoleApp.Util.Obj.PrintProperties(automationElement);
    }
}
