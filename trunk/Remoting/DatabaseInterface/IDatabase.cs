using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dk.iha
{
  public interface IDatabase : IEnumerable<int>
  {
    string GetValue();
  }
}
