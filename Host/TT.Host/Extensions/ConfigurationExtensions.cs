using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using TT.Host.ConfigSections;

namespace TT.Host.Extensions
{
    public static class ConfigurationExtensions
    {
        private static IConfiguration _configuration;

        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;

            return services
                .RegisterConfig()
                .AddConfigSingletons();
        }

        private static IServiceCollection RegisterConfig(this IServiceCollection services)
        {
            return services
                .Configure<DataAccessConfigSection>(_configuration.GetSection(DataAccessConfigSection.Name));
        }

        private static IServiceCollection AddConfigSingletons(this IServiceCollection services)
        {
            return services
                .AddSingleton(_configuration.GetSection(DataAccessConfigSection.Name).Get<DataAccessConfigSection>());
        }
    }
}
