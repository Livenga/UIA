namespace WA32;

using System;
using System.Runtime.InteropServices;
using System.Text;


/// <summary></summary>
public class User32
{
    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowTextW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowText(IntPtr hWnd, [Out]StringBuilder lpString, int nMaxCount);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool IsWindow(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetClassNameW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetClassName(
            IntPtr hWnd,
            [Out]StringBuilder lpClassName,
            int nMaxCount);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumChildWindows", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnumPropsExW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int EnumPropsEx(IntPtr hWnd, EnumPropsExProc lpEnumFunc, IntPtr lParam);

    // EM_SETMODIFY True, IntPtr.Zero
    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);


    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "MessageBoxW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int MessageBox(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint   uType);


    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "EnableWindow", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetComboBoxInfo", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetComboBoxInfo(IntPtr hWnd, ref ComboBoxInfo pcbi);


    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowLongW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

    /// <summary></summary>
    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

    /// <summary></summary>
    public static class Wrap
    {
        /// <summary>
        /// </summary>
        public static IntPtr GetWindowLong(IntPtr hWnd, int nIndex) => IntPtr.Size switch
        {
            8 => User32.GetWindowLongPtr(hWnd, nIndex),
            _ => User32.GetWindowLong(hWnd, nIndex),
        };

        /// <summary>
        /// </summary>
        public static int MessageBoxShow(
                string           caption,
                string           text,
                MessageBoxIcon   icon   = MessageBoxIcon.Information,
                MessageBoxButton button = MessageBoxButton.OK,
                MessageBoxModal  modal  = MessageBoxModal.App) =>
            User32.MessageBox(
                    hWnd:      IntPtr.Zero,
                    lpText:    text,
                    lpCaption: caption,
                    uType:     (uint)icon | (uint)button | (uint)modal);


        /// <summary>
        /// </summary>
        public static string? GetWindowText(IntPtr hWnd)
        {
            var length = User32.GetWindowTextLength(hWnd);
            if(length == 0)
            {
                Kernel32.ThrowWin32Exception();
                return null;
            }

            var sb = new StringBuilder(length + 1);
            var ret = User32.GetWindowText(hWnd, sb, length + 1);
            if(ret == 0)
            {
                Kernel32.ThrowWin32Exception();
            }

            return sb.ToString();
        }

        /// <summary>
        /// </summary>
        public static string? GetClassName(
                IntPtr hWnd,
                int length = 2048)
        {
            var sb = new StringBuilder(length);
            var ret = User32.GetClassName(hWnd, sb, length);

            if(ret == 0)
            {
                Kernel32.ThrowWin32Exception();
                return null;
            }

            return sb.ToString(0, ret);
        }
    }
}
