using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Zetatech.Accelerate.Domain;
using Zetatech.Accelerate.Exceptions;
using Zetatech.Tracking.Domain.Entities;

namespace Zetatech.Tracking.Web.Middlewares;

public sealed class ApiKeyMiddleware
{
    private const String HeaderName = "x-api-key";
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var repository = httpContext.RequestServices.GetRequiredService<IRepository<ApiKeyEntity>>();

        if (!httpContext.Request.Headers.ContainsKey(HeaderName))
        {
            throw new ForbiddenException($"The header '{HeaderName}' is missing");
        }

        if (Guid.TryParse(httpContext.Request.Headers[HeaderName], out var apiKey))
        {
            _ = repository.Single(x => x.Enabled && x.Id == apiKey) ?? throw new UnauthorizedException($"The api key '{apiKey}' is invalid");
        }
        else
        {
            throw new UnauthorizedException($"The api key'{apiKey}' has an invalid format");
        }

        await _next(httpContext);
    }
}
