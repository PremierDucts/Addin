using System;
using System.IO;
using System.Reflection;
using Addins.Helpers;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Addins
{
    public class SerilogClass
    {
        private static string projectName = GetProjectName();

        // public static readonly Serilog.ILogger _log;
        public static Serilog.ILogger Log = new LoggerConfiguration().
                    MinimumLevel.Debug().Enrich.WithProperty("Project", projectName).
                WriteTo.File(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/AddinsPremierducts", "Logs"), 
                    $"Logs_.log"), rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] [{Project}] {Message:lj}{NewLine}{Exception}").
                CreateLogger();
        public static string GetProjectName()
        {
            Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            return assembly.GetName().Name;
        }

    }
    
}