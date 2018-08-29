using Hubert.Common.Method.Log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hubert.Common.Method.Configuration
{
    public static class ConfigHelper
    {
        private static IConfiguration _configuration;
        static ConfigHelper()
        {
            var fileName = "appsettings.json";

            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");
            var filePath = $"{directory}/{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }
            var builder = new ConfigurationBuilder().AddJsonFile(filePath, optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string GetString(string key)
        {
            Logger.Info("Key：" + key);
            return _configuration.GetSection(key).Value;
        }
        public static bool GetBoolean(string key)
        {
            string strValue = GetString(key);
            bool value;
            if (!bool.TryParse(strValue, out value))
            {
                return false;
            }
            return value;
        }
    }
}
