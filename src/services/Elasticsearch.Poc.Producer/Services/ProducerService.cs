using Elasticsearch.Poc.Helpers;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Poc.Producer.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IElasticsearchHelper<DefaultElasticsearchOptions> _elasticsearchHelper;
        private readonly ILogger<ProducerService> _logger;

        public ProducerService(
            IElasticsearchHelper<DefaultElasticsearchOptions> elasticsearchHelper,
            ILogger<ProducerService> logger)
        {
            _elasticsearchHelper = elasticsearchHelper;
            _logger = logger;
        }

        public async Task PublishMessagesAsync(CancellationToken cancellationToken = default)
        {
            var cluster = _elasticsearchHelper.GetCluster();
            var ping = await cluster.PingOperations.PingAsync();

            _logger.LogInformation("Ping: {Ping}", ping);

            await Task.Delay(300, cancellationToken);
        }
    }
}