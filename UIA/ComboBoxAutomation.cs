namespace UIA;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;


/// <summary></summary>
public static class ComboBoxAutomation
{
    /// <summary>
    /// ComboBoxInfo 及び AutomationElement を用いて ComboBox.Items で表示される文字列の一覧を取得.
    /// </summary>
    public static IEnumerable<string> GetItems(
            AutomationElement ae,
            bool isExpand = false) =>
        GetItems(new IntPtr(ae.Current.NativeWindowHandle), isExpand);


    /// <summary>
    /// ComboBoxInfo 及び AutomationElement を用いて ComboBox.Items で表示される文字列の一覧を取得.
    /// </summary>
    public static IEnumerable<string> GetItems(
            IntPtr hWnd,
            bool isExpand = false)
    {
        WA32.ComboBoxInfo cbi = new ();
        if(! WA32.User32.GetComboBoxInfo(hWnd, ref cbi))
        {
            WA32.Kernel32.ThrowWin32Exception();
        }

#if DEBUG
        DebugObj.PrintFields(cbi);
#endif

        if(isExpand)
        {
            var aeComboBox = AutomationElement.FromHandle(hWnd);
            object? expandPattern = null;

            if(aeComboBox.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out expandPattern)
                    && expandPattern != null
                    && expandPattern is ExpandCollapsePattern _expandPattern)
            {
                _expandPattern.Expand();
            }
        }

        return AutomationElement.FromHandle(cbi.hWndList)
            .FindAll(
                    scope: TreeScope.Subtree,
                    condition: new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)).Cast<AutomationElement>()
            .Select(ae => ae.Current.Name);
    }


    /// <summary>
    /// ComboBox の変更イベントを通知
    /// </summary>
    /// <param name="hOwner"></param>
    /// <param name="hComboBox"></param>
    public static bool NotifyEditChange(
            IntPtr hOwner,
            IntPtr hComboBox)
    {
        // https://stackoverflow.com/questions/1468165/how-to-send-a-cbn-selchange-message-when-using-cb-setcursel
        IntPtr ptr = WA32.User32.Wrap.GetWindowLong(
                hWnd:   hComboBox,
                nIndex: (int)-12/* GWD_ID */);
#if DEBUG
        Debug.WriteLine($"DEBUG | {ptr.ToInt32()}(0x{ptr.ToInt32():X})");
#endif

        // https://nleo.hatenadiary.org/entry/20151210/1449757279
        WA32.User32.SendMessage(
                hOwner,
                0x0111, /* WM_COMMAND */
                /* CBN_SELCHANGE = 1 */
                new IntPtr((1 << 16) | (ptr.ToInt32() & 0xFFFF)),
                hComboBox);

        return true;
    }
}
