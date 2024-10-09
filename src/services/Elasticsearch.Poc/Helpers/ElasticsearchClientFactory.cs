using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Poc.Helpers
{
    public class ElasticsearchClientFactory<TOptions> : IElasticsearchClientFactory
        where TOptions : class, IElasticsearchOptions
    {
        private readonly Lazy<ElasticsearchClient> _client;
        private readonly TOptions _options;

        public ElasticsearchClientFactory(
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
            var nodes = _options.Clusters
                .SelectMany(x => x.Nodes!)
                .Select(x => new Uri(x.Url!));
            var pool = new StaticNodePool(nodes);
            var settings = new ElasticsearchClientSettings(pool);

            return settings;
        }

        public ElasticsearchClient Client => _client.Value;
    }
}