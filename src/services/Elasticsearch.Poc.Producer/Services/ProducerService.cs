namespace Elasticsearch.Poc.Producer.Services
{
    public class ProducerService : IProducerService
    {
        public async Task PublishMessagesAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(300, cancellationToken);
        }
    }
}