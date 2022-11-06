namespace UIA.ConsoleApp;


using System.Diagnostics;
using System.Linq;
using System.Reflection;


/// <summary></summary>
public static class Obj
{
    /// <summary></summary>
    public static void PrintProperties<T>(T value) where T : notnull
    {
        var t     = value.GetType();
        var attr  = BindingFlags.Public | BindingFlags.Instance;
        var props = t.GetType().GetProperties(attr).OrderBy(prop => prop.Name);

        Debug.WriteLine($"DEBUG | {t.GetType().FullName}");
        foreach(var prop in props)
        {
            Debug.WriteLine($"\t{prop.Name} {prop.GetValue(value)?.ToString() ?? string.Empty}");
        }
    }
}
