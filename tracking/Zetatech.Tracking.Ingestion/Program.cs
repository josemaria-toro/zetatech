using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.DependencyInjection;
using Zetatech.Tracking.DependencyInjection;

namespace Zetatech.Tracking;

public class Program
{
    public static void Main(String[] argv)
    {
        var webAppBuilder = WebApplication.CreateBuilder(argv);

        webAppBuilder.Configuration.Configure();
        webAppBuilder.Services.AddDomainRepositories()
                              .AddMessagePublishers()
                              .AddMvcComponents()
                              .AddRateLimitsPolicies();

        var webApp = webAppBuilder.Build();

        webApp.UseCustomMiddlewares()
              .UseMvcFeatures()
              .Run();
    }
}