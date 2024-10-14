using Elasticsearch.Poc.Operations;

namespace Elasticsearch.Poc.Clusters
{
    public interface IElasticsearchCluster
    {
        IPingOperations PingOperations { get; }
    }
}