using Microsoft.Extensions.DependencyInjection;
using TT.Host.Middlewares;

namespace TT.Host.Extensions
{
    public static class RegisterMiddlewaresExtensions
    {
        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddTransient<RequestLogMiddleware>();
            services.AddTransient<RedirectFromDisabledControllersMiddleware>();

            return services;
        }
    }
}
