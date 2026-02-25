using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.Application;
using Zetatech.Accelerate.Infrastructure;

namespace Zetatech.Tracking.DependencyInjection;

public static class Publishers
{
    public static IServiceCollection AddMessagePublishers(this IServiceCollection serviceCollection)
    {
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var configService = serviceProvider.GetRequiredService<IConfiguration>();

        serviceCollection.Configure<PublisherOptions>(options =>
        {
            options.ConnectionString = configService.GetConnectionString("rabbitmq");
            options.Exchange = configService.GetValue<String>("appSettings:exchange");
        });

        serviceCollection.AddSingleton<IPublisher, Publisher>();

        return serviceCollection;
    }
}