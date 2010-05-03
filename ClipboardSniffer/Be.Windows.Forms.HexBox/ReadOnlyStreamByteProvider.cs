using System;
using System.IO;

namespace Be.Windows.Forms
{
  public class ReadOnlyStreamByteProvider : IByteProvider
  {
    private readonly Stream stream;

    public ReadOnlyStreamByteProvider(Stream stream)
    {
      this.stream = stream;
    }

    #region IByteProvider Members

    public byte ReadByte(long index)
    {
      stream.Seek(index, SeekOrigin.Begin);
      return (byte)stream.ReadByte();
    }

    public void WriteByte(long index, byte value)
    {
      throw new NotImplementedException();
    }

    public void InsertBytes(long index, byte[] bs)
    {
      throw new NotImplementedException();
    }

    public void DeleteBytes(long index, long length)
    {
      throw new NotImplementedException();
    }

    public long Length
    {
      get { return stream.Length; }
    }

    public event EventHandler LengthChanged;

    public bool HasChanges()
    {
      throw new NotImplementedException();
    }

    public void ApplyChanges()
    {
      throw new NotImplementedException();
    }

    public event EventHandler Changed;

    public bool SupportsWriteByte()
    {
      return false;
    }

    public bool SupportsInsertBytes()
    {
      return false;
    }

    public bool SupportsDeleteBytes()
    {
      return false;
    }

    #endregion
  }
}
