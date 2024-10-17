using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Elasticsearch.Poc.Clusters;
using Elasticsearch.Poc.Operations;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Poc.Helpers
{
    public class ElasticsearchHelper<TOptions> : IElasticsearchHelper<TOptions>
        where TOptions : class, IElasticsearchOptions
    {
        private readonly Lazy<ElasticsearchClient> _client;
        private readonly TOptions _options;

        public ElasticsearchHelper(
            IOptions<TOptions> options)
        {
            _options = options.Value;
            _client = new Lazy<ElasticsearchClient>(() =>
            {
                var settings = GetSettings();
                return new ElasticsearchClient(settings);
            });
        }

        private IElasticsearchClientSettings GetSettings()
        {
            var cluster = _options.Cluster;
            var uri = new Uri(cluster.Url!);
            var settings = new ElasticsearchClientSettings(uri);

            if (!string.IsNullOrWhiteSpace(cluster.Username))
            {
                settings.Authentication(new BasicAuthentication(cluster.Username!, cluster.Password!));
            }

            return settings;
        }

        private ElasticsearchClient Client => _client.Value;

        public IElasticsearchCluster GetCluster()
        {
            return new ElasticsearchCluster(
                pingOperations: new PingOperations(Client));
        }
    }
}