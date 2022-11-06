namespace UIA.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;
using UIA;


/// <summary></summary>
[TestClass]
public class AutomationTextBoxTest
{
    private readonly WA32.HWindow _hWindow;
    private readonly AutomationElement _aeWindow;

    public AutomationTextBoxTest()
    {
        _hWindow = WA32.HWindow.FindAll()
            .First(h => h.Text?.Contains("UIA Example Window") ?? false);

        _aeWindow = AutomationElement.FromHandle(_hWindow.Handle);
    }


    /// <summary></summary>
    [TestMethod]
    public void SendMessageText()
    {
        var aeEdit = _aeWindow.FindAll(
                scope: TreeScope.Subtree,
                condition: new AndCondition(new Condition[] {
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "exampleText"),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)}))
            .Cast<AutomationElement>()
            .First();

        foreach(var p in aeEdit.GetSupportedPatterns())
        {
            Debug.WriteLine($"{p.Id}\t{p.ProgrammaticName}");
        }

        
        object? objPattern = null;
        if(aeEdit.TryGetCurrentPattern(ValuePattern.Pattern, out objPattern)
                && objPattern is ValuePattern _valuePattern)
        {
            //_valuePattern.SetValue($"Hello, World! {Guid.NewGuid().ToString()}");
            Debug.WriteLine($"{_valuePattern.Current.Value}");

            WA32.User32.EnableWindow(
                    new IntPtr(aeEdit.Current.NativeWindowHandle),
                    true);
            /*
            WA32.User32.SendMessage(
                    new IntPtr(aeEdit.Current.NativeWindowHandle),
                    0x00cf,
                    new IntPtr(0),
                    IntPtr.Zero);
                    */
        }

        if(aeEdit.TryGetCurrentPattern(TextPattern.Pattern, out objPattern)
                && objPattern is TextPattern _textPattern)
        {
        }

    }
}
