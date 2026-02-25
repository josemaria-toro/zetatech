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
[Route("/api/v1/requests")]
public sealed class RequestsController : ControllerBase
{
    private readonly IPublisher _publisher;

    public RequestsController(IPublisher publisher)
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
            var trackingObject = Request.ReadAsJson<Request>();
            var metadata = new Dictionary<String, Object>
            {
                { "apiKey", Request.Headers["x-api-key"].FirstOrDefault() },
                { "body", trackingObject.Body },
                { "correlationId", trackingObject.CorrelationId },
                { "duration", trackingObject.Duration?.TotalMilliseconds },
                { "endpoint", trackingObject.EndPoint },
                { "ipAddress", trackingObject.IpAddress?.ToString() },
                { "metadata", trackingObject.Metadata },
                { "name", trackingObject.Name },
                { "response", trackingObject.Response },
                { "statusCode", trackingObject.StatusCode },
                { "success", trackingObject.Success },
                { "trackerIpAddress", HttpContext.Connection?.RemoteIpAddress?.ToString() },
                { "type", trackingObject.Type }
            };

            _publisher.Publish(metadata, "requests");
        }
        catch (Exception ex)
        {
            throw new ValidationException("Request contents cannot be readed", ex);
        }

        return Accepted();
    }
}