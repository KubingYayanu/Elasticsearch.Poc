namespace Elasticsearch.Poc.Helpers
{
    public class DefaultElasticsearchOptions : IElasticsearchOptions
    {
        public string Section => "Elasticsearch";

        public List<Cluster> Clusters { get; set; } = new();
    }
}