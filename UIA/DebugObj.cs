namespace UIA;

using System;
using System.Diagnostics;
using System.Linq;


#if DEBUG
/// <summary></summary>
public static class DebugObj
{
    /// <summary></summary>
    public static void PrintProeprties<T>(
            T value,
            string nullValue = "") where T : notnull
    {
        try
        {
            Debug.WriteLine($"DEBUG | {value.GetType().FullName}");

            var maxNameLength = value.GetType().GetProperties().Max(p => p.Name.Length);
            foreach(var prop in value.GetType()
                    .GetProperties()
                    .OrderBy(prop => prop.Name))
            {
                try
                {
                    Debug.WriteLine(string.Format(
                                $"\t{{0,-{maxNameLength}}} {{1}}",
                                prop.Name,
                                prop.GetValue(value)?.ToString() ?? nullValue));
                }
                catch { }
            }

            Debug.WriteLine(string.Empty);
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"ERROR | {ex.GetType().FullName} {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
        }
    }

    /// <summary></summary>
    public static void PrintFields<T>(
            T value,
            string nullValue = "") where T : notnull
    {
        try
        {
            Debug.WriteLine($"DEBUG | {value.GetType().FullName}");

            var maxNameLength = typeof(T).GetFields().Max(p => p.Name.Length);
            foreach(var prop in typeof(T)
                    .GetFields()
                    .OrderBy(f => f.Name))
            {
                try
                {
                    Debug.WriteLine(string.Format(
                                $"\t{{0,-{maxNameLength}}} {{1}}",
                                prop.Name,
                                prop.GetValue(value)?.ToString() ?? nullValue));
                }
                catch { }
            }

            Debug.WriteLine(string.Empty);
        }
        catch { }
    }
}
#endif
