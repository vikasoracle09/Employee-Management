
using System.Configuration;

namespace ServiceLayer
{
 /// <summary>
 /// Read Config value
 /// </summary>
  internal class ConfigReader
   {
       
     /// <summary>
     /// 
     /// </summary>
      internal ConfigReader()
       {
           var execpath = GetType().Assembly.Location;

           var data = ConfigurationManager.OpenExeConfiguration(execpath).AppSettings.Settings.CurrentConfiguration;

           AppKey = data.AppSettings.Settings["Token"].Value;
            BasePath = data.AppSettings.Settings["BasePath"].Value;
       }
      /// <summary>
      /// 
      /// </summary>
      public string AppKey { get; }

        /// <summary>
        /// 
        /// </summary>
        public string BasePath { get; }
    }
}
