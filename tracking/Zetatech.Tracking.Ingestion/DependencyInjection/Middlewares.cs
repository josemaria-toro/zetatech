using Microsoft.AspNetCore.Builder;
using Zetatech.Accelerate.Web.Middlewares;
using Zetatech.Tracking.Web.Middlewares;

namespace Zetatech.Tracking.DependencyInjection;

public static class Middlewares
{
    public static WebApplication UseCustomMiddlewares(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<ExceptionsMiddleware>()
                      .UseMiddleware<ApiKeyMiddleware>();

        return webApplication;
    }
}