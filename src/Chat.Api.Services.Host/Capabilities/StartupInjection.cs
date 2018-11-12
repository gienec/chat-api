using Chat.Api.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Api.Services.Host.Capabilities
{
    public static class StartupInjection
    {
        public static IServiceCollection ConfigureInjection(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            services.AddSingleton<IUserRepository, UserRepository> ();
            services.AddSingleton<IChannelRepository, ChannelRepository> ();
            services.AddSignalR();
            
            return services;
        }
    }
}