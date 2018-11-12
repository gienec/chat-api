using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Chat.Api.Services.Host.Capabilities
{
    public static class StartupConfig
    {
        public static IConfigurationRoot ConfigureConfig(this IHostingEnvironment environment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

            return builder
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}