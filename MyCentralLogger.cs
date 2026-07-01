using Microsoft.Build.Framework;
using System;
using System.IO;

namespace MsBuildForwardingLoggerRepro;

public sealed class MyCentralLogger : ILogger
{
    public LoggerVerbosity Verbosity  { get; set; }

    public string? Parameters { get; set; }

    public void Initialize(IEventSource eventSource)
    {
        var path = Path.Combine(Environment.GetEnvironmentVariable("TMP"), "CentralLogger.txt"); 
        File.AppendAllText(path, "Initialize called\n");    
    }

    public void Shutdown()
    {
    }
}
