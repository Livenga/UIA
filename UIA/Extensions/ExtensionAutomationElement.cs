namespace UIA.Extensions;

using System;
using System.Windows.Automation;
using WA32;


/// <summary></summary>
public static class ExtensionAutomationElement
{
    /// <summary></summary>
    public static AutomationElement GetParent(this AutomationElement ae)
    {
        var handle = User32.GetParent(new IntPtr(ae.Current.NativeWindowHandle));
        if(handle == IntPtr.Zero)
        {
            throw new Exception();
        }

        return AutomationElement.FromHandle(handle);
    }
}
