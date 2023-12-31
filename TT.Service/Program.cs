
using TT.Host.ConfigSections;
using TT.Host.Extensions;
using TT.Host.Middlewares;

namespace TT.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            var serviceCollection = builder.Services;

            serviceCollection
                .AddConfig(configuration)
                .AddMiddlewares()
                .AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app
                .UseMiddleware<RedirectFromDisabledControllersMiddleware>()
                .UseMiddleware<RequestLogMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}