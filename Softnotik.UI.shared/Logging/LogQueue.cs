﻿using Softnotik.UI.Shared.Models;
using System.Threading.Channels;

namespace Softnotik.UI.Shared.Logging
{
    public class LogQueue
    {
        private readonly Channel<LogMessage> _channel = Channel.CreateUnbounded<LogMessage>(new UnboundedChannelOptions
        {
            SingleReader = true
        });

        public ValueTask WriteLog(LogMessage message, CancellationToken token = default) => _channel.Writer.WriteAsync(message, token);

        public IAsyncEnumerable<LogMessage> ReadLogs(CancellationToken token = default) => _channel.Reader.ReadAllAsync(token);
    }
}
