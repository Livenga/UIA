namespace UIA.ControlGallery;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary></summary>
public partial class MainForm : Form
{
    /// <summary></summary>
    public string StatusMessage
    {
        set => messageStrip.Text = value;
        get => messageStrip.Text;
    }


    /// <summary></summary>
    public MainForm()
    {
        InitializeComponent();
    }


    /// <summary></summary>
    private void OnExampleTextChanged(object source, EventArgs e)
    {
        if(source is TextBox tbx)
        {
            StatusMessage = $"{tbx.Name}({tbx.Text}) {nameof(OnExampleTextChanged)}";
        }
    }

    /// <summary></summary>
    private void OnExampleSelectorSelectedIndexChanged(object source, EventArgs e)
    {
        if(source is ComboBox cbx)
        {
            StatusMessage = $"Example Selector Selected #{cbx.SelectedIndex}";
        }
    }

    /// <summary></summary>
    private void OnExampleCheckBoxCheckedChanged(object source, EventArgs e)
    {
        if(source is CheckBox cbx)
        {
            StatusMessage = $"{cbx.Name}({cbx.Checked}) {nameof(OnExampleCheckBoxCheckedChanged)}";
        }
    }

    /// <summary></summary>
    private void OnRaiseMessageBoxClick(object source, EventArgs e)
    {
        MessageBox.Show(
                caption: "情報",
                text: $"メッセージ {Guid.NewGuid().ToString()}",
                icon: MessageBoxIcon.Information,
                buttons: MessageBoxButtons.OK);
    }

    /// <summary></summary>
    private void OnMessageClearClick(object source, EventArgs e)
    {
        StatusMessage = "###";
    }

    /// <summary></summary>
    private void OnDecideClick(object source, EventArgs e)
    {
        var result = MessageBox.Show(
                caption: "確認",
                text: "角煮",
                icon: MessageBoxIcon.Question,
                buttons: MessageBoxButtons.YesNo);

        if(result == DialogResult.Yes)
        {
            Close();
        }
    }
}
