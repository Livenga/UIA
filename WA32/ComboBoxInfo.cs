 namespace WA32;

 using System;
 using System.Runtime.InteropServices;


///  <summary></summary>
[StructLayout(LayoutKind.Sequential)]
 public struct ComboBoxInfo
{
    public Int32  cbSize;
    public Rect   rcItem;
    public Rect   rcButton;
    public Int32  buttonStatuc;
    public IntPtr hWndCombo;
    public IntPtr hWndEdit;
    public IntPtr hWndList;
}
