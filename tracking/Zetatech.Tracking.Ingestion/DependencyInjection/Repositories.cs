using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.Domain;
using Zetatech.Accelerate.Infrastructure;
using Zetatech.Tracking.Domain.Entities;

namespace Zetatech.Tracking.DependencyInjection;

public static class Repositories
{
    public static IServiceCollection AddDomainRepositories(this IServiceCollection serviceCollection)
    {
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var configService = serviceProvider.GetRequiredService<IConfiguration>();

        serviceCollection.Configure<RepositoryOptions>(options =>
        {
            options.ConnectionString = configService.GetConnectionString("postgresql");
        });

        serviceCollection.AddSingleton<IRepository<ApiKeyEntity>, Repository<ApiKeyEntity>>();

        return serviceCollection;
    }
}