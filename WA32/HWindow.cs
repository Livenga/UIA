namespace WA32;

using System;
using System.Collections.Generic;
using System.Text;


/// <summary></summary>
public class HWindow
{
    /// <summary>Window ハンドル</summary>
    public IntPtr Handle => _handle;

    /// <summary>Window テキスト</summary>
    public string? Text => _text;

    /// <summary>プロセスID</summary>
    public int ProcessId => _processId;

    /// <summary>スレッドID</summary>
    public int ThreadId => _threadId;

    /// <summary>モジュールファイル名</summary>
    public string? ModuleFile => _moduleFile;


    private readonly IntPtr _handle;
    private readonly string? _text;
    private readonly int _processId;
    private readonly int _threadId;
    private readonly string? _moduleFile;


    /// <summary></summary>
    private HWindow(
            IntPtr handle,
            string? text,
            int processId,
            int threadId,
            string? moduleFile)
    {
        _handle = handle;
        _text = text;
        _processId = processId;
        _threadId = threadId;
        _moduleFile = moduleFile;
    }


    private static List<HWindow>? _hWindows = null;

    /// <summary>全 Window の取得</summary>
    public static IEnumerable<HWindow> FindAll()
    {
        if(_hWindows != null)
        {
            throw new InvalidOperationException();
        }

        _hWindows = new ();

        WA32.User32.EnumWindows(OnEnumWindows, IntPtr.Zero);

        var hWindows = _hWindows.ToArray();

        _hWindows.Clear();
        _hWindows = null;

        return hWindows;
    }

    /// <summary></summary>
    private static bool OnEnumWindows(IntPtr hWnd, IntPtr lParam)
    {
        // Window Text
        string? windowText = User32.Wrap
            .GetWindowText(hWnd);

        // Process and Thread ID
        int processId = 0;
        int threadId = WA32.User32.GetWindowThreadProcessId(hWnd, out processId);

        // Module Filename
        var hProcess = WA32.Kernel32.OpenProcess(0x0410, true, processId);
        var moduleFileNameBuffer = new StringBuilder(1024);
        var moduleFileLength = WA32.Kernel32.GetModuleFileNameEx(
                hProcess,
                IntPtr.Zero,
                moduleFileNameBuffer,
                moduleFileNameBuffer.Capacity);

        string? moduleFile = null;
        if(moduleFileLength > 0)
        {
            moduleFile = moduleFileNameBuffer.ToString(0, moduleFileLength);
        }

        WA32.Kernel32.CloseHandle(hProcess);

        var hWindow = new HWindow(
                handle: hWnd,
                text: windowText,
                processId: processId,
                threadId: threadId,
                moduleFile: moduleFile);

        _hWindows?.Add(hWindow);

        return true;
    }
}
