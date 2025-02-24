using Cradle.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cradle.Shared.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCradle(this IServiceCollection services)
        {
            Player player = new("Player");
            services.AddSingleton<IPlayerView>(player);
            return services;
        }
    }
}
