using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.Application;
using Zetatech.Accelerate.DependencyInjection;
using Zetatech.Tracking.DependencyInjection;

namespace Zetatech.Tracking;

public class Program
{
    public static void Main(String[] argv)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure()
                         .AddDomainRepositories()
                         .AddMessageSubscribers();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var messageSubscriber = serviceProvider.GetRequiredService<ISubscriber<Dictionary<String, Object>>>();

        messageSubscriber.Subscribe("dependencies");
        messageSubscriber.Subscribe("errors");
        messageSubscriber.Subscribe("events");
        messageSubscriber.Subscribe("metrics");
        messageSubscriber.Subscribe("pageviews");
        messageSubscriber.Subscribe("requests");
        messageSubscriber.Subscribe("tests");
        messageSubscriber.Subscribe("traces");

        Task.Delay(Timeout.Infinite)
            .Wait();
    }
}