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
      wiimote.SetLEDs(false, true, true, false);
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
    }

    void wiimoteChanged(object sender, WiimoteChangedEventArgs e)
    {
      if (InvokeRequired)
        BeginInvoke(new EventHandler<WiimoteChangedEventArgs>(wiimoteChanged), sender, e);
      else
        updateButtonState(e.WiimoteState.ButtonState);
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
