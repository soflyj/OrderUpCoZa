using Microsoft.Extensions.DependencyInjection;

namespace OrderUp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application-specific services here
            // Example: services.AddScoped<IMyService, MyService>();
            return services;
        }
    }
}