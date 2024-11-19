using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flogging.Core
{
    static public class Flogger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Flogger()
        {
            _perfLogger = new LoggerConfiguration()
                .WriteTo.File(path: "C:\\Users\\alifmuqri.hazm\\source\\repos\\FloggingPS\\Flogging.Core\\Logs\\perf.txt")
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: "C:\\Users\\alifmuqri.hazm\\source\\repos\\FloggingPS\\Flogging.Core\\Logs\\usage.txt")
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(path: "C:\\Users\\alifmuqri.hazm\\source\\repos\\FloggingPS\\Flogging.Core\\Logs\\error.txt")
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: "C:\\Users\\alifmuqri.hazm\\source\\repos\\FloggingPS\\Flogging.Core\\Logs\\diagnostic.txt")
                .CreateLogger();

        }

        public static void WritePerf(FlogDetail infoToLog)
        {
            _perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteUsage(FlogDetail infoToLog)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteError(FlogDetail infoToLog)
        {
            _errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteDiagnostic(FlogDetail infoToLog)
        {
            var writeDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
            if (!writeDiagnostics)
                return;

            _diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }
    }
}
