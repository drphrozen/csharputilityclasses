using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleUpdater
{
  class Config
  {
    public static Config Instance { get { return _config.Value; } }
    
    public DateTime LastModified { get; set; }
    public string InstallerLocation { get; set; }

    public string ConfigPath { get; private set; }

    protected Config()
    {
      ConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SimpleUpdaterConfig.ini");
      LastModified = new DateTime(1970,1,1);
      InstallerLocation = "";
    }

    private static readonly Lazy<Config> _config = new Lazy<Config>(() => new Config());

    public void Load()
    {
      using (var reader = new StreamReader(File.OpenRead(ConfigPath)))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          var elements = line.Split(new[] { '=' }, 2);
          if (elements.Length < 2)
            continue;
          var key = elements[0].Trim().ToLower();
          var value = elements[1].Trim();
          switch (key)
          {
            case "lastmodified":
              LastModified = new DateTime(long.Parse(value), DateTimeKind.Utc);
              break;
            case "installerlocation":
              InstallerLocation = value;
              break;
          }
        } 
      }

    }

    public void Save()
    {
      using (var writer = new StreamWriter(File.OpenWrite(ConfigPath)))
      {
        writer.WriteLine("LastModified=" + LastModified.ToUniversalTime().Ticks);
        writer.WriteLine("InstallerLocation=" + InstallerLocation ?? "");
      }
    }
  }
}
