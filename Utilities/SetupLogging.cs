using System;
using System.IO;
using Serilog;

namespace AddinsPremierducts
{
    public class SetupLogging
    {
            public static Serilog.ILogger AppLog = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName + "/Logs/Logs.log"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
    }
}