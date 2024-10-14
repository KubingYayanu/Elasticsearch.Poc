using Elasticsearch.Poc.Clusters;

namespace Elasticsearch.Poc.Helpers
{
    public interface IElasticsearchHelper<TOptions>
        where TOptions : class, IElasticsearchOptions
    {
        IElasticsearchCluster GetCluster();
    }
}