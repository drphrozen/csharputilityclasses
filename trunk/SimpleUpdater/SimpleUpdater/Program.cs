using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;

namespace SimpleUpdater
{
  class Program
  {
    static void Main(string[] args)
    {
      Config.Instance.Load();
      DateTime lastUpdatedDate = Config.Instance.LastModified;
      string url = Config.Instance.InstallerLocation;
      HttpWebResponse response;
      if (IsUpdated(url, lastUpdatedDate, out response))
      {
        Console.WriteLine(string.Format("Update available ({0})", response.LastModified));
      }
    }

    static bool IsUpdated(String url, DateTime lastModified, out HttpWebResponse response)
    {
      var request = (HttpWebRequest)WebRequest.Create(url);
      request.IfModifiedSince = lastModified;
      try
      {
        response = (HttpWebResponse)request.GetResponse();
      }catch(WebException e)
      {
        response = (HttpWebResponse) e.Response;
        if (response.StatusCode != HttpStatusCode.NotModified)
          return false;
        throw;
      }
      return true;
    }
  }
}
