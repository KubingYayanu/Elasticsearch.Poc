using Elastic.Clients.Elasticsearch;

namespace Elasticsearch.Poc.Operations
{
    public class PingOperations : IPingOperations
    {
        private readonly ElasticsearchClient _client;

        public PingOperations(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task<bool> PingAsync()
        {
            var response = await _client.PingAsync();
            return response.IsValidResponse;
        }
    }
}