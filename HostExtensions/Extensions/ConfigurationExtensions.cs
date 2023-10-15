using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TT.Host.ConfigSections;

namespace TT.Host.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<DataAccessConfigSection>(configuration.GetSection(DataAccessConfigSection.Name);
        }
    }
}
