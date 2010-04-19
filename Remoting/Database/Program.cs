using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace dk.iha
{
  class Program
  {
    static void Main(string[] args)
    {
      //Create a TCP channel
      TcpChannel serverChannel = new TcpChannel(50001);
      //IpcChannel theChannel = new IpcChannel("DatabasePort");

			/* Register the channel so that clients can
			 * connect to the server */
			ChannelServices.RegisterChannel(serverChannel, false);

      // Show the URIs associated with the channel.
      ChannelDataStore channelData = (ChannelDataStore) serverChannel.ChannelData;
      foreach (string uri in channelData.ChannelUris)
      {
        Console.WriteLine("The channel URI is {0}.", uri);
      }

			//Register the service on the channel
			RemotingConfiguration.ApplicationName = "DatabaseApplication";
			RemotingConfiguration.RegisterWellKnownServiceType(
					typeof(Database),
					"SimpleDatabase",
					WellKnownObjectMode.SingleCall);
      Console.WriteLine("GetRegisteredWellKnownServiceTypes():");
      foreach (var registeredWellKnownServiceType in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
      {
        Console.WriteLine("\tMode: " + registeredWellKnownServiceType.Mode);
        Console.WriteLine("\tType: " + registeredWellKnownServiceType.ObjectType);
        string[] urls = serverChannel.GetUrlsForUri(registeredWellKnownServiceType.ObjectUri);
        if(urls == null) continue;
        foreach (var objectURL in urls)
        {
          string objectURI;
          string channelURI = serverChannel.Parse(objectURL, out objectURI);
          Console.WriteLine("The object URI is {0}.", objectURI);
          Console.WriteLine("The channel URI is {0}.", channelURI);
          Console.WriteLine("The object URL is {0}.", objectURL);
        }
      }

			/*Start the server and keep it running so that clients
			 * can connect to it. May be aborted by keypress */
			Console.WriteLine("Press Enter to end this server process..");
			Console.Read();
    }
  }

  class Database : MarshalByRefObject, IDatabase
  {
    #region IDatabase Members

    public string GetValue()
    {
      return "Yeah!!!";
    }

    #endregion

    private readonly int[] _data = new [] {1,2,3,4,5};


    #region IEnumerable<int> Members

    public IEnumerator<int> GetEnumerator()
    {
      List<int> list = new List<int>(_data.Length);
      list.AddRange(_data);
      return list.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _data.GetEnumerator();
    }

    #endregion
  }
}
