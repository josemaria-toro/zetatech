using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zetatech.Accelerate.Application;
using Zetatech.Tracking.Extensions;

namespace Zetatech.Tracking.Web.Controllers;

[ApiController]
[Route("/api/v1/dependencies")]
public sealed class DependenciesController : ControllerBase
{
    private readonly IPublisher _publisher;

    public DependenciesController(IPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> PublishAsync()
    {
        if (!Request.IsJsonContentType())
        {
            throw new ValidationException("Unexpected content type header value");
        }

        try
        {
            var trackingObject = Request.ReadAsJson<Dependency>();
            var metadata = new Dictionary<String, Object>
            {
                { "apiKey", Request.Headers["x-api-key"].FirstOrDefault() },
                { "correlationId", trackingObject.CorrelationId },
                { "dataInput", trackingObject.DataInput },
                { "dataOutput", trackingObject.DataOutput },
                { "duration", trackingObject.Duration?.TotalMilliseconds },
                { "metadata", trackingObject.Metadata },
                { "name", trackingObject.Name },
                { "success", trackingObject.Success },
                { "target", trackingObject.Target },
                { "trackerIpAddress", HttpContext.Connection?.RemoteIpAddress?.ToString() },
                { "type", trackingObject.Type }
            };

            _publisher.Publish(metadata, "dependencies");
        }
        catch (Exception ex)
        {
            throw new ValidationException("Request contents cannot be readed", ex);
        }

        return Accepted();
    }
}