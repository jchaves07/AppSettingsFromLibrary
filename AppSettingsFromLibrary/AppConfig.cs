using System.IO;
using Microsoft.Extensions.Configuration;

namespace AppSettingsFromLibrary
{
    public static class AppConfig
    {
        /// <summary>
        /// Get Default ConnectionString
        /// </summary>
        /// <returns>Default ConnectionString</returns>
        public static string GetConnectionString()
        {
            return GetConnectionString("DefaultConnection");
        }
        /// <summary>
        /// Get ConnectionString by ConnectionName
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns>ConnectionString</returns>
        public static string GetConnectionString(string ConnectionName)
        {
            var configuration = GetConfiguration();
            var result = configuration.GetSection($"ConnectionStrings:{ConnectionName}").Value;
            return result;
        }
        /// <summary>
        /// Get Configuration Root
        /// </summary>
        /// <returns>ConfigurationRoot</returns>
        public static IConfigurationRoot GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .Build();
            return configuration;
        }
    }
}
