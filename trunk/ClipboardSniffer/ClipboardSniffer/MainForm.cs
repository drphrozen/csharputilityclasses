using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.IO;

namespace ClipboardSniffer
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      textBox = new TextBox {Dock = DockStyle.Fill, Multiline = true, Visible = true};
      hexBox = new HexBox {Dock = DockStyle.Fill, Visible = false, LineInfoVisible = true, StringViewVisible = true, VScrollBarVisible = true};
      panel.Controls.AddRange( new Control[] {textBox, hexBox});
      activeControl = textBox;
    }

    private IDataObject dataObject;
    private TextBox textBox;
    private HexBox hexBox;
    private Control activeControl;

    private void Button1Click(object sender, EventArgs e)
    {
      dataObject = Clipboard.GetDataObject();
      if (dataObject == null) return;
      comboBoxAutoConvert.Items.Clear();
      string[] autoFormats = dataObject.GetFormats(true);
      Array.Sort(autoFormats);
      string[] nativeFormats = dataObject.GetFormats(false);
      Array.Sort(nativeFormats);

      LinkedList<string> tmp = new LinkedList<string>(autoFormats);
      foreach (var format in nativeFormats)
        tmp.Remove(format);

      comboBoxAutoConvert.Items.AddRange(tmp.ToArray());
      comboBoxNative.Items.Clear();
      comboBoxNative.Items.AddRange(dataObject.GetFormats(false));
    }

    private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox comboBox = (ComboBox)sender;
      string format = (string)comboBox.SelectedItem;
      if(format == null || dataObject == null) return;
      object data = dataObject.GetData(format, sender == comboBoxAutoConvert);
      Type type = data.GetType();
      Text = type.FullName;

      SuspendLayout();
      if(activeControl != null)
        activeControl.Visible = false;
      activeControl = null;
      if(data is Stream)
      {
        Console.WriteLine(data.GetType());
        hexBox.ByteProvider = new ReadOnlyStreamByteProvider((Stream)data);
        activeControl = hexBox;
      } else if(data is string)
      {
        textBox.Text = (string)data;
        activeControl = textBox;
      }
      if(activeControl != null)
        activeControl.Visible = true;
      ResumeLayout(true);
    }
  }
}
