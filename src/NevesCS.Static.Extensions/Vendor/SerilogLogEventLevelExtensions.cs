using Microsoft.Extensions.Logging;

using NevesCS.Static.Utils.Vendor;

using Serilog.Events;

namespace NevesCS.Static.Extensions.Vendor
{
    public static class SerilogLogEventLevelExtensions
    {
        public static LogEventLevel ToLogEventLevel(this LogLevel logLevel)
        {
            return SerilogUtils.MapLogEventLevelFrom(logLevel);
        }
    }
}
