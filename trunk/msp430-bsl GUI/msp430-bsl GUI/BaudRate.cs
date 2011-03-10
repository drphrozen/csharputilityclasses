using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace msp430_bsl_GUI
{
  public class BaudRate
  {
    public int Value { get; private set; }

    public static BaudRate[] BaudRates = new[] { new BaudRate(9600), new BaudRate(19200), new BaudRate(38400) };

    public BaudRate(int value)
    {
      Value = value;
    }

    public override string ToString()
    {
      return Value.ToString();
    }
  }
}
