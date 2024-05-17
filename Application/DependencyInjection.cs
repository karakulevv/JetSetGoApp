using Application.Clients.Options;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TripXOptions>(configuration.GetSection(nameof(TripXOptions)));

            services.AddTransient<IManager, Manager>();

            return services;
        }
    }
}
