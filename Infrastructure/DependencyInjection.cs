using Application.Clients.Interfaces;
using Domain.Cache.Interfaces;
using Domain.Cache;
using Infrastructure.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Clients.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register HttpClient for TripXClient
        services.AddHttpClient<ITripXClient, TripXClient>(client =>
        {
            var options = configuration.GetSection(nameof(TripXOptions)).Get<TripXOptions>();
            if (!string.IsNullOrEmpty(options.BaseAddress))
            {
                client.BaseAddress = new Uri(options.BaseAddress);
            }
        });

        // Register InMemoryCache with logging
        services.AddSingleton<ICache, InMemoryCache>();

        return services;
    }
}
