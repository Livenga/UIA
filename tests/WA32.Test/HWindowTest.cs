namespace WA32.Test;

using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;


public class HWindowTest
{
    private readonly ITestOutputHelper _outputHelper;


    /// <summary></summary>
    public HWindowTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }


    /// <summary></summary>
    [Fact]
    public void FindAllTest()
    {
        foreach(var hWindow in WA32.HWindow.FindAll())
        {
            foreach(var prop in hWindow.GetType().GetProperties())
            {
                _outputHelper.WriteLine($"{prop.Name}\t{prop.GetValue(hWindow)?.ToString() ?? "(null)"}");
            }
            _outputHelper.WriteLine(string.Empty);
        }
    }
}
