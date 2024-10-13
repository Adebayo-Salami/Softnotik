namespace Softnotik.UI.Shared.Logging
{
    public class LoggerJob
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LogReader _reader;
        private readonly CancellationTokenSource _source;
        private readonly CancellationToken _stoppingToken;

        public LoggerJob(IHttpClientFactory httpClientFactory, LogReader reader)
        {
            _httpClientFactory = httpClientFactory;
            _reader = reader;
            _source = new CancellationTokenSource();
            _stoppingToken = _source.Token;
        }

        // TODO: Implement Batch Log Messages To Database
        public async Task Start()
        {
            await foreach (var message in _reader.Read(_stoppingToken))
            {
                //await _httpClientFactory.CreateClient("LoggerJob").PostAsJsonAsync("/logs", message, cancellationToken: _stoppingToken);
            }
        }

        public void Stop() => _source.Cancel();
    }
}
