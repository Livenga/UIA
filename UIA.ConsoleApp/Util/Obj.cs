namespace UIA.ConsoleApp.Util;

using System;
using System.Diagnostics;
using System.Linq;



/// <summary>Obj</summary>
internal static class Obj
{
    /// <summary>value で指定されたオブジェクトのパブリックプロパティを全て表示</summary>
    public static void PrintProperties<T>(T value) where T : notnull
    {
        var type = value.GetType();
        Debug.WriteLine($"{type.FullName}");

        var maxLength = type.GetProperties().Max(p => p.Name.Length);
        var format = $"\t{{0,{-maxLength}}} {1}";

        foreach(var prop in type.GetProperties())
        {
            try
            {
                Debug.WriteLine(string.Format(
                            format,
                            prop.Name,
                            prop.GetValue(value)?.ToString() ?? "(null)"));
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"ERROR | {prop.Name} {ex.GetType().FullName} {ex.Message}");
            }
        }

        Debug.WriteLine(string.Empty);
    }
}
