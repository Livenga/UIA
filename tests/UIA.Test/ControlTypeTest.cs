namespace UIA.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;


/// <summary></summary>
[TestClass]
public class ControlTypeTest
{
    [TestMethod]
    public void GetAllTypesTest()
    {
        foreach(var ct in typeof(ControlType).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => f.GetValue(null))
            .Where(o => o != null && o is ControlType)
            .Cast<ControlType>()
            .OrderBy(ct => ct.Id))
        {
            Debug.WriteLine($"{ct.Id}(0x{ct.Id:X8})\t{ct.ProgrammaticName}");
        }
    }
}
