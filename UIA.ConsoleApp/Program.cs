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
    /// <summary></summary>
    static void Main(string[] args)
    {
        var hWindow = WA32.HWindow
            .FindAll()
            .FirstOrDefault(h => h.Text == "MainForm") ?? throw new NullReferenceException();
        Console.Error.WriteLine($"{hWindow.Text}");
    }
}
