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
[Route("/api/v1/metrics")]
public sealed class MetricsController : ControllerBase
{
    private readonly IPublisher _publisher;

    public MetricsController(IPublisher publisher)
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
            var trackingObject = Request.ReadAsJson<Metric>();
            var metadata = new Dictionary<String, Object>
            {
                { "apiKey", Request.Headers["x-api-key"].FirstOrDefault() },
                { "correlationId", trackingObject.CorrelationId },
                { "dimension", trackingObject.Dimension },
                { "metadata", trackingObject.Metadata },
                { "name", trackingObject.Name },
                { "trackerIpAddress", HttpContext.Connection?.RemoteIpAddress?.ToString() },
                { "value", trackingObject.Value }
            };

            _publisher.Publish(metadata, "metrics");
        }
        catch (Exception ex)
        {
            throw new ValidationException("Request contents cannot be readed", ex);
        }

        return Accepted();
    }
}