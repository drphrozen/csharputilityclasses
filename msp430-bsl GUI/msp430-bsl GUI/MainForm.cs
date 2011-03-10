using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using WinFormPlusPlus;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace msp430_bsl_GUI
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      fileFormatComboBox.Items.AddRange(FileFormat.FileFormats);
      fileFormatComboBox.Items.Add("Detect");
      var serialPorts = SerialPortInfo.GetSerialPorts();
      comPortComboBox.Items.AddRange(serialPorts);
      if (serialPorts.Length > 0)
        comPortComboBox.SelectedItem = serialPorts.DefaultIfEmpty(serialPorts[0]).First(sp => sp.Name == GuiModel.SerialPortInfo.Name);
      speedComboBox.Items.AddRange(BaudRate.BaudRates);

      _oneShot = new OneShot(fileFormatLabel, lbl => CheckFormat(), 300);
      _oneShot.Reset();

      speedComboBox.SelectedIndex = 0;
      fileFormatComboBox.SelectedIndex = 0;

      LoadGuiModel();
    }

    private readonly string _configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config.xml");
    private GuiModel GuiModel { get; set;}
    private readonly OneShot _oneShot;

    void LoadGuiModel()
    {
      var serializer = new XmlSerializer(typeof(GuiModel));
      if (File.Exists(_configFile))
        GuiModel = serializer.Deserialize(File.OpenRead(_configFile)) as GuiModel;
      if(GuiModel == null)
        GuiModel = new GuiModel();
      GuiModel.OnVerifyFailed += (s, arg) => WriteErrorLine(arg.Message);
    }

    void SaveGuiModel()
    {
      UpdateGuiModel();
      var serializer = new XmlSerializer(typeof (GuiModel));
      serializer.Serialize(File.Create(_configFile), GuiModel);
    }

    private void FilenameTextBoxTextChanged(object sender, EventArgs e)
    {
      _oneShot.Reset();
    }

    private FileFormat _selectedFileFormat;
    private FileFormat SelectedFileFormat
    {
      get { return _selectedFileFormat; }
      set {
        _selectedFileFormat = value;
        fileFormatLabel.Text = value.Format;
      }
    }

    private void CheckFormat()
    {
      var selected = fileFormatComboBox.SelectedItem as FileFormat;
      SelectedFileFormat = selected ?? DetectFormat();
    }

    private FileFormat DetectFormat()
    {
      FileFormat ff;
      return FileFormat.RegisteredFormats.TryGetValue(Path.GetExtension(filenameTextBox.Text), out ff) ? ff : FileFormat.DefaultFileFormat;
    }

    private void FileFormatComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      CheckFormat();
    }

    private void ComPortComboBoxDropDown(object sender, EventArgs e)
    {
      comPortComboBox.Items.Clear();
      comPortComboBox.Items.AddRange(SerialPortInfo.GetSerialPorts());
    }

    private volatile bool _isRunning;
    private void ProgramButtonClick(object sender, EventArgs e)
    {
      if (_isRunning) return;

      UpdateGuiModel();
      if (GuiModel.VerifyModel() == false) return;
      
      _isRunning = true;

      var processInfo = new ProcessStartInfo(@"C:\Users\drphrozen\Documents\My Dropbox\Arbejde\pybsl\pybsl\bin\msp430-bsl.exe", "-h") { CreateNoWindow = true, UseShellExecute = false, RedirectStandardError = true, RedirectStandardOutput = true, Arguments = GuiModel.BuildArguments() };
      var process = new Process { StartInfo = processInfo };
      process.ErrorDataReceived += ProcessErrorDataReceived;
      process.OutputDataReceived += ProcessOutputDataReceived;
      WriteLine(DateTime.Now.ToShortTimeString() + " > " + Path.GetFileNameWithoutExtension(processInfo.FileName) + " " + processInfo.Arguments, Color.Green);
      Task.Factory.StartNew(() =>
      {
        try
        {
          if (process.Start())
          {
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
            if (process.ExitCode != 1)
              WriteErrorLine("Process failed with exit code " + process.ExitCode);
            process.Close();
          }else
          {
            WriteErrorLine("Could not start the process!");
          }
        } finally
        {
          _isRunning = false;
        }
      });
    }

    private void UpdateGuiModel()
    {
      GuiModel.Filename = filenameTextBox.Text;
      GuiModel.BaudRate = speedComboBox.SelectedItem as BaudRate;
      GuiModel.SerialPortInfo = comPortComboBox.SelectedItem as SerialPortInfo;
      GuiModel.FileFormat = _selectedFileFormat;
      GuiModel.InvertRST = invertResetCheckBox.Checked;
      GuiModel.InvertTEST = invertTestCheckBox.Checked;
      GuiModel.MassErase = massEraseCheckBox.Checked;
      GuiModel.EraseCheck = eraseCheckCheckBox.Checked;
      GuiModel.ProgramFile = programFileCheckBox.Checked;
      GuiModel.VerifyByFile = verifyFileCheckBox.Checked;
    }

    void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
      WriteLine(e.Data);
    }

    void ProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
      WriteLine(e.Data);
    }

    private void WriteLine(string text)
    {
      consoleOutputRichTextBox.BeginInvokeIfRequired(c => WriteLine(text, Color.White));
    }

    private void WriteErrorLine(string text)
    {
      consoleOutputRichTextBox.BeginInvokeIfRequired(c => WriteLine(text, Color.Red));
    }

    private void WriteLine(string text, Color c)
    {
      consoleOutputRichTextBox.SelectionLength = 0;
      consoleOutputRichTextBox.SelectionStart = consoleOutputRichTextBox.TextLength;
      consoleOutputRichTextBox.SelectionColor = c;
      consoleOutputRichTextBox.AppendText("\n" + text);
      consoleOutputRichTextBox.ScrollToCaret();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveGuiModel();
    }
  }
}
