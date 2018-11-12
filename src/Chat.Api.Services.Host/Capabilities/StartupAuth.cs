using Microsoft.Extensions.DependencyInjection;

namespace Chat.Api.Services.Host.Capabilities
{
    public static class StartupAuth
    {
        public static IServiceCollection ConfigureInjection(this IServiceCollection services)
        {

            return services;
        }
    }
}