using Microsoft.Build.Framework;
using System;
using System.IO;

namespace MsBuildForwardingLoggerRepro;

public sealed class MyForwardingLogger : IForwardingLogger
{
    public IEventRedirector BuildEventRedirector { get; set; } = default!;
    public int NodeId { get; set; } 
    public LoggerVerbosity Verbosity { get; set; } 
    public string? Parameters { get; set; }

    public void Initialize(IEventSource eventSource, int nodeCount)
    {
        Initialize(eventSource);
    }

    public void Initialize(IEventSource eventSource)
    {
        var path = Path.Combine(Environment.GetEnvironmentVariable("TMP"), "ForwardingLogger.txt"); 
        File.AppendAllText(path, "Initialize called\n");
    }

    public void Shutdown()
    {
    }
}



