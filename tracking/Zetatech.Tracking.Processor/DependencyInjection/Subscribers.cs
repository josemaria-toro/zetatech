using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.Application;
using Zetatech.Accelerate.Infrastructure;
using Zetatech.Tracking.Infrastructure;

namespace Zetatech.Tracking.DependencyInjection;

public static class Subscribers
{
    public static IServiceCollection AddMessageSubscribers(this IServiceCollection serviceCollection)
    {
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var configService = serviceProvider.GetRequiredService<IConfiguration>();

        serviceCollection.Configure<SubscriberOptions>(options =>
        {
            options.ConnectionString = configService.GetConnectionString("rabbitmq");
        });

        serviceCollection.AddSingleton<ISubscriber<Dictionary<String, Object>>, TrackingSubscriber>();

        return serviceCollection;
    }
}