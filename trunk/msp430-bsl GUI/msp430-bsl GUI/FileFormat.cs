using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace msp430_bsl_GUI
{
  class FileFormat
  {
    public string[] Extensions { get; private set; }
    public string Format { get; private set; }
    public string Command { get; private set; }
    public static readonly FileFormat[] FileFormats;
    public static readonly FileFormat DefaultFileFormat = new FileFormat("ELF", null);
    public static readonly Dictionary<string, FileFormat> RegisteredFormats;

    static FileFormat()
    {
      RegisteredFormats = new Dictionary<string, FileFormat>();
      var IntelHEX = new FileFormat("Intel HEX", "--intelhex");
      var TIText = new FileFormat("TIText", "--titext");
      RegisteredFormats.Add(".hex", IntelHEX);
      RegisteredFormats.Add(".a43", IntelHEX);
      RegisteredFormats.Add(".txt", TIText);
      FileFormats = new[] { IntelHEX, TIText };
    }

    private FileFormat(string format, string command, params string[] extensions)
    {
      Format = format;
      Command = command;
      Extensions = extensions;
      foreach (var extension in extensions)
        RegisteredFormats.Add(extension, this);
    }

    public override string ToString()
    {
      return Format;
    }
  }

}
