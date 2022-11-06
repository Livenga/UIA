namespace UIA;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
public class UIAOperator
{
    private readonly IntPtr _handle;
    private readonly AutomationElement _aeWindow;


    /// <summary></summary>
    public UIAOperator(IntPtr handle)
    {
        _handle = handle;
        _aeWindow = AutomationElement.FromHandle(handle);
    }


    /// <summary></summary>
    public IEnumerable<AutomationElement> GetAllElements()
    {
        int processId = 0;
        WA32.User32.GetWindowThreadProcessId(
                _handle,
                out processId);

#if DEBUG
        Debug.WriteLine($"DEBUG | {processId}");
#endif
         return _aeWindow.FindAll(
                 scope: TreeScope.Subtree,
                 condition: new PropertyCondition(
                     property: AutomationElement.ProcessIdProperty,
                     value:   processId))
             .Cast<AutomationElement>();
    }

    /// <summary></summary>
    public IEnumerable<AutomationElement> FindByControlType(ControlType controlType)
    {
        return _aeWindow.FindAll(
                scope: TreeScope.Subtree,
                condition: new PropertyCondition(
                    property: AutomationElement.ControlTypeProperty,
                    value: controlType))
            .Cast<AutomationElement>();
    }
}
