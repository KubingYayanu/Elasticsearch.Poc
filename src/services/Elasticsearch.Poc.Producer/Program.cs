using Elasticsearch.Poc.Helpers;
using Elasticsearch.Poc.IoC;
using Elasticsearch.Poc.Producer.IoC;
using Elasticsearch.Poc.Producer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Elasticsearch.Poc.Producer;

class Program
{
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (sender, eventArgs) =>
        {
            Console.WriteLine("Cancellation requested...");
            cts.Cancel();
            eventArgs.Cancel = true; // 防止程序立即終止
        };

        var host = CreateHostBuilder(args).Build();

        var producer = host.Services.GetRequiredService<IProducerService>();
        var producerTask = producer.PublishMessagesAsync(cts.Token);

        try
        {
            await host.RunAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Host run cancelled.");
        }
        finally
        {
            Console.WriteLine("Host shutting down...");
            await host.StopAsync(cts.Token);

            // Ensure the producer task is completed
            try
            {
                await producerTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Producer task cancelled.");
            }
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: true);
                builder.AddCommandLine(args);
            })
            .UseSerilog((host, config) =>
            {
                config.ReadFrom.Configuration(host.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console();
            })
            .ConfigureServices(ConfigureServices);
    }

    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.AddElasticsearchHelper<DefaultElasticsearchOptions>(host.Configuration);
        services.AddApplicationServices(host.Configuration);
    }
}