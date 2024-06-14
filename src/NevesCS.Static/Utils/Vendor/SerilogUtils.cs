using Microsoft.Extensions.Logging;

using Serilog.Events;

namespace NevesCS.Static.Utils.Vendor
{
    public static class SerilogUtils
    {
        public static LogEventLevel MapLogEventLevelFrom(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => LogEventLevel.Verbose,
                LogLevel.Debug => LogEventLevel.Debug,
                LogLevel.Information => LogEventLevel.Information,
                LogLevel.Warning => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                LogLevel.Critical or LogLevel.None => LogEventLevel.Fatal,

                _ => throw new NotImplementedException($"{nameof(LogLevel)}({logLevel})"),
            };
        }
    }
}
