namespace Elasticsearch.Poc.Helpers
{
    public interface IElasticsearchOptions
    {
        /// <summary>
        /// appsettings.json Elasticsearch section 
        /// </summary>
        string Section { get; }

        List<Cluster> Clusters { get; set; }
    }

    public class Cluster
    {
        public List<Node>? Nodes { get; set; }
    }

    public class Node
    {
        public string? Url { get; set; }
    }
}