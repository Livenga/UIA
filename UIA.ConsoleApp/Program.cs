namespace UIA.ConsoleApp;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
internal class Program
{
    /// <summary></summary>
    static void Main(string[] args)
    {
        /*
       // 静的パブリックフィールドに存在する AutomationProperty タイプの要素を取得, 表示.
        var automationProperties = typeof(AutomationElement).Assembly.GetTypes()
            .SelectMany(t => t.GetFields(BindingFlags.Static | BindingFlags.Public)
                    .Where(f => f.FieldType == typeof(AutomationProperty))
                    .Select(f => new { Name = $"{t.FullName}.{f.Name}", Value = f.GetValue(null) as AutomationProperty }) );
        foreach(var ap in automationProperties)
        {
            Debug.WriteLine($"{ap.Name}\t{ap.Value?.Id}");
        }
        */

        if(args.Length == 0)
        {
            return;
        }

        var hWindows = WA32.HWindow.FindAll();
        var hWindow = hWindows.FirstOrDefault(hWindow => hWindow.Text == args[0]);
        if(hWindow == null)
        {
            return;
        }

        Debug.WriteLine($"{hWindow.ProcessId} {hWindow.Text}");
        var automationElement = AutomationElement.FromHandle(hWindow.Handle);
        //UIA.ConsoleApp.Util.Obj.PrintProperties(automationElement);

        var eInputAudioFilesList = automationElement.FindAll(
                scope: TreeScope.Element | TreeScope.Descendants,
                condition: new PropertyCondition(
                    property: AutomationElement.AutomationIdProperty,
                    value: ""))
            .Cast<AutomationElement>()
            .FirstOrDefault() ?? throw new NullReferenceException();

        Debug.WriteLine(eInputAudioFilesList);
        ConsoleApp.Util.Obj.PrintProperties(eInputAudioFilesList.Current);
    }
}
