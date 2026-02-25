using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Zetatech.Accelerate.Application;
using Zetatech.Accelerate.Domain;
using Zetatech.Accelerate.Exceptions;
using Zetatech.Accelerate.Extensions;
using Zetatech.Accelerate.Infrastructure;
using Zetatech.Accelerate.Infrastructure.Abstractions;
using Zetatech.Tracking.Domain.Entities;

namespace Zetatech.Tracking.Infrastructure;

public sealed class TrackingSubscriber : BaseSubscriber<Dictionary<String, Object>>
{
    private readonly IRepository<DependencyEntity> _dependenciesRepository;
    private readonly IRepository<ErrorEntity> _errorsRepository;
    private readonly IRepository<EventEntity> _eventsRepository;
    private readonly IRepository<MetricEntity> _metricsRepository;
    private readonly IRepository<PageViewEntity> _pageViewsRepository;
    private readonly IRepository<RequestEntity> _requestsRepository;
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly IRepository<TestEntity> _testsRepository;
    private readonly IRepository<TraceEntity> _tracesRepository;

    public TrackingSubscriber(IOptions<SubscriberOptions> options,
                              IRepository<DependencyEntity> dependenciesRepository,
                              IRepository<ErrorEntity> errorsRepository,
                              IRepository<EventEntity> eventsRepository,
                              IRepository<MetricEntity> metricsRepository,
                              IRepository<PageViewEntity> pageViewsRepository,
                              IRepository<RequestEntity> requestsRepository,
                              IRepository<TestEntity> testsRepository,
                              IRepository<TraceEntity> tracesRepository) : base(options)
    {
        _dependenciesRepository = dependenciesRepository;
        _errorsRepository = errorsRepository;
        _eventsRepository = eventsRepository;
        _metricsRepository = metricsRepository;
        _pageViewsRepository = pageViewsRepository;
        _requestsRepository = requestsRepository;
        _serializerOptions = JsonSerializerOptions.Default.GetDefaultOptions();
        _testsRepository = testsRepository;
        _tracesRepository = tracesRepository;
    }

    protected override void OnMessageReceived(String queueName, IMessage<Dictionary<String, Object>> message)
    {
        switch (queueName)
        {
            case "dependencies":
                SaveDependency(message);
                break;
            case "errors":
                SaveError(message);
                break;
            case "events":
                SaveEvent(message);
                break;
            case "metrics":
                SaveMetric(message);
                break;
            case "pageviews":
                SavePageView(message);
                break;
            case "requests":
                SaveRequest(message);
                break;
            case "tests":
                SaveTest(message);
                break;
            case "traces":
                SaveTrace(message);
                break;
        }
    }
    private void SaveDependency(IMessage<Dictionary<String, Object>> message)
    {
        _dependenciesRepository.Insert(new DependencyEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            DataInput = message.Body["dataInput"]?.ToString(),
            DataOutput = message.Body["dataOutput"]?.ToString(),
            Duration = Double.Parse(message.Body["duration"]?.ToString() ?? throw new ValidationException("Missing value for duration")),
            Id = message.Id,
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for name"))?.ToString(),
            Success = Boolean.Parse(message.Body["success"]?.ToString() ?? throw new ValidationException("Missing value for success")),
            Target = (message.Body["target"] ?? throw new ValidationException("Missing value for target"))?.ToString(),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString(),
            Type = (message.Body["type"] ?? throw new ValidationException("Missing value for type"))?.ToString(),
        });
    }
    private void SaveError(IMessage<Dictionary<String, Object>> message)
    {
        _errorsRepository.Insert(new ErrorEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Id = message.Id,
            Message = (message.Body["message"] ?? throw new ValidationException("Missing value for message"))?.ToString(),
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Source = (message.Body["source"] ?? throw new ValidationException("Missing value for source"))?.ToString(),
            Timestamp = message.Timestamp,
            StackTrace = (message.Body["stacktrace"] ?? throw new ValidationException("Missing value for stacktrace"))?.ToString(),
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString(),
            Type = (message.Body["type"] ?? throw new ValidationException("Missing value for type"))?.ToString()
        });
    }
    private void SaveEvent(IMessage<Dictionary<String, Object>> message)
    {
        _eventsRepository.Insert(new EventEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Id = message.Id,
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for name"))?.ToString(),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString()
        });
    }
    private void SaveMetric(IMessage<Dictionary<String, Object>> message)
    {
        _metricsRepository.Insert(new MetricEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Id = message.Id,
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for name"))?.ToString(),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString(),
            Value = Double.Parse(message.Body["value"]?.ToString() ?? throw new ValidationException("Missing value for value")),
        });
    }
    private void SavePageView(IMessage<Dictionary<String, Object>> message)
    {
        _pageViewsRepository.Insert(new PageViewEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Device = (message.Body["device"] ?? throw new ValidationException("Missing value for device"))?.ToString(),
            Duration = Double.Parse(message.Body["duration"]?.ToString() ?? throw new ValidationException("Missing value for duration")),
            Id = message.Id,
            IpAddress = (message.Body["ipAddress"] ?? throw new ValidationException("Missing value for ip address"))?.ToString(),
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for name"))?.ToString(),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString(),
            Url = message.Body["url"]?.ToString(),
            UserAgent = message.Body["userAgent"]?.ToString()
        });
    }
    private void SaveRequest(IMessage<Dictionary<String, Object>> message)
    {
        _requestsRepository.Insert(new RequestEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            Body = message.Body["body"]?.ToString(),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Duration = Double.Parse(message.Body["duration"]?.ToString() ?? throw new ValidationException("Missing value for duration")),
            Endpoint = (message.Body["endpoint"] ?? throw new ValidationException("Missing value for endpoint"))?.ToString(),
            Id = message.Id,
            IpAddress = (message.Body["ipAddress"] ?? throw new ValidationException("Missing value for ip address"))?.ToString(),
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for name"))?.ToString(),
            Response = message.Body["response"]?.ToString(),
            StatusCode = Int32.Parse(message.Body["statusCode"]?.ToString() ?? "0"),
            Success = Boolean.Parse(message.Body["success"]?.ToString() ?? throw new ValidationException("Missing value for success")),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString(),
            Type = (message.Body["type"] ?? throw new ValidationException("Missing value for type"))?.ToString()
        });
    }
    private void SaveTest(IMessage<Dictionary<String, Object>> message)
    {
        _testsRepository.Insert(new TestEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Duration = Double.Parse(message.Body["duration"]?.ToString() ?? throw new ValidationException("Missing value for duration")),
            Id = message.Id,
            Message = (message.Body["message"] ?? throw new ValidationException("Missing value for message"))?.ToString(),
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Name = (message.Body["name"] ?? throw new ValidationException("Missing value for tracker name"))?.ToString(),
            Success = Boolean.Parse(message.Body["success"]?.ToString() ?? throw new ValidationException("Missing value for success")),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString()
        });
    }
    private void SaveTrace(IMessage<Dictionary<String, Object>> message)
    {
        _tracesRepository.Insert(new TraceEntity
        {
            ApiKeyId = Guid.Parse(message.Body["apiKey"]?.ToString() ?? throw new ValidationException("Missing value for api key")),
            CorrelationId = Guid.Parse(message.Body["correlationId"]?.ToString() ?? throw new ValidationException("Missing value for correlation id")),
            Id = message.Id,
            Message = (message.Body["message"] ?? throw new ValidationException("Missing value for message"))?.ToString(),
            Metadata = JsonSerializer.Serialize(message.Body["metadata"] ?? new(), _serializerOptions),
            Source = (message.Body["source"] ?? throw new ValidationException("Missing value for source"))?.ToString(),
            Timestamp = message.Timestamp,
            TrackerIpAddress = (message.Body["trackerIpAddress"] ?? throw new ValidationException("Missing value for tracker ip address"))?.ToString()
        });
    }
}