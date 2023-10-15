using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.Host.ConfigSections;

namespace TT.Host.Middlewares
{
    public class RedirectFromDisabledControllersMiddleware : IMiddleware
    {
        private readonly DisabledFunctionalConfigSection _disabledFunctional;

        public RedirectFromDisabledControllersMiddleware(
            DisabledFunctionalConfigSection disabledFunctional)
        {
            _disabledFunctional = disabledFunctional;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var routeData = context.Request.HttpContext.GetRouteData();

            var controller = routeData.Values["controller"].ToString();

            if (!string.IsNullOrWhiteSpace(controller) &&
                _disabledFunctional.DisabledControllers.Contains(GetControllerClassname(controller)))
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Controller not found.");
            }

            await next.Invoke(context);
        }

        private string GetControllerClassname(string controllerName) => $"{controllerName}Controller";
    }
}
