using Microsoft.Build.Framework;
using System.IO;

namespace MsBuildForwardingLoggerRepro;

public sealed class MyCentralLogger : ILogger
{
    public LoggerVerbosity Verbosity  { get; set; }

    public string? Parameters { get; set; }

    public void Initialize(IEventSource eventSource)
    {
        File.AppendAllText(@"E:\temp\CentralLogger.txt", "Initialized\n");
    }

    public void Shutdown()
    {
    }
}
