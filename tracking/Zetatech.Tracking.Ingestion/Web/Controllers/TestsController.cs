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
[Route("/api/v1/tests")]
public sealed class TestsController : ControllerBase
{
    private readonly IPublisher _publisher;

    public TestsController(IPublisher publisher)
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
            var trackingObject = Request.ReadAsJson<Test>();
            var metadata = new Dictionary<String, Object>
            {
                { "apiKey", Request.Headers["x-api-key"].FirstOrDefault() },
                { "correlationId", trackingObject.CorrelationId },
                { "duration", trackingObject.Duration?.TotalMilliseconds },
                { "message", trackingObject.Message },
                { "metadata", trackingObject.Metadata },
                { "name", trackingObject.Name },
                { "success", trackingObject.Success },
                { "trackerIpAddress", HttpContext.Connection?.RemoteIpAddress?.ToString() }
            };

            _publisher.Publish(metadata, "tests");
        }
        catch (Exception ex)
        {
            throw new ValidationException("Test contents cannot be readed", ex);
        }

        return Accepted();
    }
}