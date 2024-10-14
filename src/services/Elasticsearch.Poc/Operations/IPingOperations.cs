namespace Elasticsearch.Poc.Operations
{
    public interface IPingOperations
    {
        Task<bool> PingAsync();
    }
}