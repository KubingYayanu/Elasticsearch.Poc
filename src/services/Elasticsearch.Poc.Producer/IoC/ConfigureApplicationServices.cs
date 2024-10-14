using Elasticsearch.Poc.Helpers;
using Elasticsearch.Poc.IoC;
using Elasticsearch.Poc.Producer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elasticsearch.Poc.Producer.IoC
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddElasticsearchHelper<DefaultElasticsearchOptions>(configuration);
            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}