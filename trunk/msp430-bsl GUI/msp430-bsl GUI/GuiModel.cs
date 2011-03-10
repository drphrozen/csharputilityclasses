using System;
using System.Collections.Generic;
using System.Linq;
using WinFormPlusPlus;
using System.IO;
using System.Runtime.Serialization;

namespace msp430_bsl_GUI
{
  [Serializable]
  public class GuiModel : ISerializable
  {
    public BaudRate BaudRate { get; set; }
    public SerialPortInfo SerialPortInfo { get; set; }
    public FileFormat FileFormat { get; set; }
    public string Filename { get; set; }
    public bool InvertRST { get; set; }
    public bool InvertTEST { get; set; }
    public bool MassErase { get; set; }
    public bool EraseCheck { get; set; }
    public bool ProgramFile { get; set; }
    public bool VerifyByFile { get; set; }

    public GuiModel()
    {
      
    }

    public bool VerifyModel()
    {
      var verified = true;
      if (BaudRate == null)
      {
        verified = false;
        if (OnVerifyFailed != null)
          OnVerifyFailed(this, new StringEventArgs("Please select a baud rate!"));
      }
      if (SerialPortInfo == null)
      {
        verified = false;
        if (OnVerifyFailed != null)
          OnVerifyFailed(this, new StringEventArgs("Please select a serial port!"));
      }
      if (FileFormat == null)
      {
        verified = false;
        if (OnVerifyFailed != null)
          OnVerifyFailed(this, new StringEventArgs("Please select a file format!"));
      }
      if (File.Exists(Filename) == false)
      {
        verified = false;
        if (OnVerifyFailed != null)
          OnVerifyFailed(this, new StringEventArgs("File not found!"));
      }
      return verified;
    }

    public class StringEventArgs : EventArgs
    {
      public string Message { get; protected set; }
      public StringEventArgs(string message)
      {
        Message = message;
      }
    }

    public event EventHandler<StringEventArgs> OnVerifyFailed;

    public string BuildArguments()
    {
      var arguments = new List<string> { "--comport=" + SerialPortInfo.Name, "--speed=" + BaudRate.Value };
      if (FileFormat != FileFormat.DefaultFileFormat) arguments.Add(FileFormat.Command);
      if (InvertRST) arguments.Add("--invert-reset");
      if (InvertTEST) arguments.Add("--invert-test");
      if (MassErase) arguments.Add("--masserase");
      if (EraseCheck) arguments.Add("--erasecheck");
      if (ProgramFile) arguments.Add("--program");
      if (VerifyByFile) arguments.Add("--verify");
      arguments.Add("\"" + Filename + "\"");
      return string.Join(" ", arguments);
    }

    public GuiModel(SerializationInfo info, StreamingContext ctxt)
    {
      BaudRate = BaudRate.BaudRates.DefaultIfEmpty(BaudRate.BaudRates[0]).First(br => br.Value == info.GetInt32("BaudRate"));
      SerialPortInfo = SerialPortInfo.GetSerialPorts().DefaultIfEmpty(null).First(spi => spi.Name == info.GetString("SerialPortInfo"));
      FileFormat = FileFormat.FileFormats.DefaultIfEmpty(FileFormat.DefaultFileFormat).First(ff => ff.Format == info.GetString("FileFormat"));
      Filename = info.GetString("Filename");
      InvertRST = info.GetBoolean("InvertRST");
      InvertTEST = info.GetBoolean("InvertTEST");
      MassErase = info.GetBoolean("MassErase");
      EraseCheck = info.GetBoolean("EraseCheck");
      ProgramFile = info.GetBoolean("ProgramFile");
      VerifyByFile = info.GetBoolean("VerifyByFile");
    }

    #region ISerializable Members

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("BaudRate", BaudRate != null ? BaudRate.Value : 0);
      info.AddValue("SerialPortInfo", SerialPortInfo != null ? SerialPortInfo.Name : "");
      info.AddValue("FileFormat", FileFormat != null ? FileFormat.Format : "");
      info.AddValue("Filename", Filename);
      info.AddValue("InvertRST", InvertRST);
      info.AddValue("InvertTEST", InvertTEST);
      info.AddValue("MassErase", MassErase);
      info.AddValue("EraseCheck", EraseCheck);
      info.AddValue("ProgramFile", ProgramFile);
      info.AddValue("VerifyByFile", VerifyByFile);
    }

    #endregion
  }
}
