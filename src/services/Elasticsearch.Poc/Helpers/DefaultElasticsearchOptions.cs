namespace Elasticsearch.Poc.Helpers
{
    public class DefaultElasticsearchOptions : IElasticsearchOptions
    {
        public string Section => "Elasticsearch";

        public Cluster Cluster { get; set; } = null!;
    }
}