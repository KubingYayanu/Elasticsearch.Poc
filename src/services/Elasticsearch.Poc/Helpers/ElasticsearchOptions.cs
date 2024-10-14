namespace Elasticsearch.Poc.Helpers
{
    public interface IElasticsearchOptions
    {
        /// <summary>
        /// appsettings.json Elasticsearch section 
        /// </summary>
        string Section { get; }

        Cluster Cluster { get; set; }
    }

    public class Cluster
    {
        public string? Url { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}