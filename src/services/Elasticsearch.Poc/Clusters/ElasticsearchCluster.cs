using Elasticsearch.Poc.Operations;

namespace Elasticsearch.Poc.Clusters
{
    public class ElasticsearchCluster : IElasticsearchCluster
    {
        private readonly IPingOperations _pingOperations;

        public ElasticsearchCluster(
            IPingOperations pingOperations)
        {
            _pingOperations = pingOperations;
        }

        public IPingOperations PingOperations => _pingOperations;
    }
}