namespace UIA.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;
using UIA;
using UIA.Extensions;


/// <summary></summary>
[TestClass]
public class UIAOperatorTest
{
    private readonly UIAOperator _operator;

    /// <summary></summary>
    public UIAOperatorTest()
    {
        var hWindow = WA32.HWindow.FindAll()
            .FirstOrDefault(h => h.Text?.Contains("UIA Example Window") ?? false) ?? throw new NullReferenceException();

        _operator = new UIAOperator(hWindow.Handle);

#if DEBUG
        Debug.WriteLine($"DEBUG | {hWindow.Handle.ToInt32():X}");
#endif
    }


    /// <summary></summary>
    [TestMethod]
    public void GetAllElementsTest()
    {
        foreach(var ae in _operator.GetAllElements())
        {
            //PrintProperties(ae.Current.ControlType);
            //Debug.WriteLine(string.Empty);
            Debug.WriteLine($"{ae.Current.ControlType.ProgrammaticName} {ae.Current.Name} {ae.Current.NativeWindowHandle} {ae.Current.AutomationId}");
            //PrintProperties(ae.Current);
        }
    }

    /// <summary></summary>
    [DataTestMethod]
    [DataRow("Button")]
    [DataRow("ComboBox")]
    public void FindByControlTypeTest(string controlType)
    {
        var _controlType = typeof(ControlType).GetField(
                name: controlType,
                bindingAttr: BindingFlags.Public | BindingFlags.Static)
            .GetValue(null) as ControlType ?? throw new NullReferenceException();

        foreach(var ae in _operator.FindByControlType(_controlType))
        {
            //Debug.WriteLine($"{ae.Current.Name} {ae.Current.NativeWindowHandle} {ae.Current.IsEnabled}");
            PrintProperties(ae.Current);
            Debug.WriteLine(string.Empty);
        }

        /*
        object? invokePattern = null;
        if(_operator.FindByControlType(_controlType)
                .First(ae => ae.Current.AutomationId == "Close")
                .TryGetCurrentPattern(InvokePattern.Pattern, out invokePattern))
        {
            Debug.WriteLine(invokePattern?.GetType().FullName ?? string.Empty);
            (invokePattern as InvokePattern)?.Invoke();
        }
        */
    }


    /// <summary>
    /// </summary>
    [TestMethod]
    public void FindByControlTypeAllTest()
    {
        var controlTypes = typeof(ControlType)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => f.GetValue(null))
            .Where(o => o != null && o is ControlType)
            .Cast<ControlType>()
            .OrderBy(ct => ct.Id);

        foreach(var controlType in controlTypes)
        {
            var aes = _operator.FindByControlType(controlType);

            if(aes.Count() > 0)
            {
                Debug.WriteLine($"{controlType.Id}\t{controlType.ProgrammaticName}");

                foreach(var ae in aes)
                {
                    Debug.WriteLine($"\t{ae.Current.AutomationId} {ae.Current.ClassName} {ae.Current.Name} {ae.Current.IsEnabled}");
                }

                Debug.WriteLine(string.Empty);
            }
        }
    }

    /// <summary></summary>
    private void PrintProperties<T>(T value) where T : notnull
    {
        Debug.WriteLine($"{value.GetType().FullName}");
        foreach(var prop in value.GetType().GetProperties())
        {
            try
            {
                Debug.WriteLine($"\t{prop.Name} {prop.GetValue(value)?.ToString() ?? string.Empty}");
            }
            catch { }
        }
        Debug.WriteLine(string.Empty);
    }
}
