using Elasticsearch.Poc.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Elasticsearch.Poc.IoC
{
    public static class ConfigureElasticsearchServices
    {
        public static IServiceCollection AddElasticsearchHelper<TOptions>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TOptions : class, IElasticsearchOptions, new()
        {
            services.Configure<TOptions>(options => { configuration.GetSection(options.Section).Bind(options); });
            services.TryAddSingleton<IElasticsearchHelper<TOptions>, ElasticsearchHelper<TOptions>>();

            return services;
        }
    }
}