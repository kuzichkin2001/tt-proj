using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TT.Host.Middlewares
{
    public class RequestLogMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.User.AddIdentity(new ClaimsIdentity
            {
                Label = "Middleware claims identity",
            });

            return next.Invoke(context);
        }
    }
}
