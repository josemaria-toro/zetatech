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
[Route("/api/v1/traces")]
public sealed class TracesController : ControllerBase
{
    private readonly IPublisher _publisher;

    public TracesController(IPublisher publisher)
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
            var trackingObject = Request.ReadAsJson<Trace>();
            var metadata = new Dictionary<String, Object>
            {
                { "apiKey", Request.Headers["x-api-key"].FirstOrDefault() },
                { "correlationId", trackingObject.CorrelationId },
                { "message", trackingObject.Message },
                { "metadata", trackingObject.Metadata },
                { "source", trackingObject.Source },
                { "trackerIpAddress", HttpContext.Connection?.RemoteIpAddress?.ToString() }
            };

            _publisher.Publish(metadata, "traces");
        }
        catch (Exception ex)
        {
            throw new ValidationException("Trace contents cannot be readed", ex);
        }

        return Accepted();
    }
}