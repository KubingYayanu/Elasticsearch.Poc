using Elastic.Clients.Elasticsearch;

namespace Elasticsearch.Poc.Helpers
{
    public interface IElasticsearchClientFactory
    {
        ElasticsearchClient Client { get; }
    }
}