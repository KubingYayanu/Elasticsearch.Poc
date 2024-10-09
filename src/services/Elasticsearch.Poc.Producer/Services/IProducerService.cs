namespace Elasticsearch.Poc.Producer.Services
{
    public interface IProducerService
    {
        Task PublishMessagesAsync(CancellationToken cancellationToken = default);
    }
}