using Microsoft.Extensions.Logging;
using System.Text.Json;
using static Microsoft.Extensions.Logging.LogLevel;
using Softnotik.UI.Shared.Models;

#nullable disable

namespace Softnotik.UI.Shared.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly LogWriter _logWriter;

        public DatabaseLogger(LogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel is Error or Critical;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            Task.Run(async () =>
                await _logWriter.Write(JsonSerializer.Deserialize<LogMessage>(formatter(state, exception))));
        }
    }
}
