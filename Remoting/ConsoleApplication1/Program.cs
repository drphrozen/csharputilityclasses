using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;

namespace dk.iha
{
  class Program
  {
    static void Main(string[] args)
    {
      TcpChannel clientChannel = new TcpChannel();
      //IpcChannel clientChannel = new IpcChannel();
      ChannelServices.RegisterChannel(clientChannel, false);

      /* Activate the server object. Activation will bring 
       * the server object to life, and create a proxy
       * stub class of the HelloWorld. In fact, as this is a 
       * server-activated application, the call to the 
       * server is NOT performed now, but instead waits until the 
       * first request. It is thus the server who performs the
       * activation. This is the "Lazy-activation pattern" known 
       * from e.g. CORBA */
      IDatabase database = (IDatabase)Activator.GetObject(
        typeof(IDatabase),
        (clientChannel.GetType() == typeof(TcpChannel) ? "tcp://192.168.5.1:50001/SimpleDatabase" : "ipc://DatabasePort/SimpleDatabase" ));

      Console.WriteLine(database.GetValue());
      foreach (var data in database)
      {
        Console.WriteLine(data);
      }

      IEnumerator<int> enumerator = database.GetEnumerator();
      Console.Read();
      while (enumerator.MoveNext())
      {
        Console.WriteLine(enumerator.Current);
        Console.Read();
      }
      Console.WriteLine("Press ENTER to end this session..");
      Console.Read();
    }
  }
}
