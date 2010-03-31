using System;
using System.Windows.Forms;
using WiiMouse.Properties;
using WiimoteLib;
using Point=System.Drawing.Point;

namespace WiiMouse
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();

      wiimote = new Wiimote();
      wiimote.WiimoteChanged += wiimoteChanged;
      wiimote.Connect();
      wiimote.SetReportType(InputReport.IRAccel, true);
      wiimote.SetLEDs(++Settings.Default.index%16);
    }

    void updateButtonState(WiimoteLib.ButtonState bs)
    {
      checkBox1.Checked = bs.Left;
      checkBox2.Checked = bs.Up;
      checkBox3.Checked = bs.Right;
      checkBox4.Checked = bs.Down;
      checkBox5.Checked = bs.Minus;
      checkBox6.Checked = bs.Plus;

      Point cursorPosition = Cursor.Position;
      if (bs.Left) ++cursorPosition.X;
      else if (bs.Right) --cursorPosition.X;
      if (bs.Up) ++cursorPosition.Y;
      else if (bs.Down) --cursorPosition.Y;
      Cursor.Position = cursorPosition;

    }

    void wiimoteChanged(object sender, WiimoteChangedEventArgs e)
    {
      if (InvokeRequired)
        BeginInvoke(new EventHandler<WiimoteChangedEventArgs>(wiimoteChanged), sender, e);
      else
      {
        updateButtonState(e.WiimoteState.ButtonState);
        Text = String.Format("{0:0.00}, {1:0.00}, {2:0.00}", e.WiimoteState.AccelState.Values.X, e.WiimoteState.AccelState.Values.Y, e.WiimoteState.AccelState.Values.Z);
        foreach (var i in e.WiimoteState.IRState.IRSensors)
          Console.WriteLine(i);
      }
    }

    private Wiimote wiimote;

    private void minimizeToTray()
    {
      Hide();
      WindowState = FormWindowState.Minimized;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      if(WindowState == FormWindowState.Minimized)
        Hide();
    }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
      Show();
      WindowState = FormWindowState.Normal;
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      minimizeToTray();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing && Settings.Default.CloseToTray)
      {
        minimizeToTray();
        e.Cancel = true;
      }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings.Default.Save();
    }

  }
}
