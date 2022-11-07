namespace UIA.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using UIA;
using WA32;


/// <summary></summary>
[TestClass]
public class AutomationComboBoxTest
{
    private readonly HWindow _hWindow;
    private readonly UIAOperator _operator;


    /// <summary></summary>
    public AutomationComboBoxTest()
    {
        _hWindow = WA32.HWindow
            .FindAll()
            .First(h => h.Text?.Contains("UIA Example Window") ?? false);

        _operator = new UIAOperator(_hWindow.Handle);
    }


    /// <summary></summary>
    [TestMethod]
    public void GetComboBoxInfoTest()
    {
        var ae = _operator.FindByControlType(ControlType.ComboBox)
            .First(ae => ae.Current.AutomationId.Contains("exampleSelector"));

        var hWnd = new IntPtr(ae.Current.NativeWindowHandle);

        ComboBoxInfo cbi = new ();
        var result = User32.GetComboBoxInfo(hWnd, ref cbi);
        Debug.WriteLine($"User32.GetComboBoxInfo: {result}");
        if(result)
        {
            Debug.WriteLine($"Handle: {hWnd.ToInt32():X} {cbi.hWndList.ToInt32():X}");
            foreach(var f in cbi.GetType().GetFields())
            {
                Debug.WriteLine($"{f.Name}\t{f.GetValue(cbi)?.ToString() ?? string.Empty}");
            }

            var aeList = AutomationElement.FromHandle(cbi.hWndList);
            if(aeList != null)
            {
                //Debug.WriteLine($"{aeList?.ToString() ?? "(null)"}");
                Debug.WriteLine($"{aeList.Current.AutomationId} {aeList.Current.Name} {aeList.Current.ClassName}");

                object? selectionPattern = null;
                if(aeList.TryGetCurrentPattern(SelectionPattern.Pattern, out selectionPattern)
                        && selectionPattern is SelectionPattern _selectionPattern)
                {
                    Debug.WriteLine($"{selectionPattern?.GetType().FullName ?? "(null)"}");

                    foreach(var s in _selectionPattern.Current.GetSelection())
                    {
                        PrintProperties(s);
                    }
                }
            }
        }
    }

    /// <summary></summary>
    [TestMethod]
    public void GetItemsTest()
    {
        var aeComboBox = AutomationElement.FromHandle(_hWindow.Handle).FindFirst(
                scope: TreeScope.Subtree,
                condition: new PropertyCondition(
                    AutomationElement.ControlTypeProperty,
                    ControlType.ComboBox));

        foreach(var name in ComboBoxAutomation.GetItems(new IntPtr(aeComboBox.Current.NativeWindowHandle)))
        {
            Debug.WriteLine(name);
        }
    }


    /// <summary></summary>
    [TestMethod]
    public void NotifyEditChangeTest()
    {
        var aeComboBox = AutomationElement.FromHandle(_hWindow.Handle).FindFirst(
                scope: TreeScope.Subtree,
                condition: new PropertyCondition(
                    AutomationElement.ControlTypeProperty,
                    ControlType.ComboBox));

        ComboBoxAutomation.NotifyEditChange(
                _hWindow.Handle,
                new IntPtr(aeComboBox.Current.NativeWindowHandle));
    }

    /// <summary></summary>
    private void PrintProperties<T>(T value) where T : notnull
    {
        foreach(var p in value.GetType().GetProperties())
        {
            try
            {
                Debug.WriteLine($"{p.Name}\t{p.GetValue(value)?.ToString() ?? "(null)"}");
            }
            catch { }
        }
    }
}
