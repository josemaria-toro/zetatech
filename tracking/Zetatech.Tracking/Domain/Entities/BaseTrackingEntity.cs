using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zetatech.Accelerate.Domain.Abstractions;

namespace Zetatech.Tracking.Domain.Entities;

public abstract class BaseTrackingEntity : BaseEntity
{
    [Required]
    [Column("c_uid_api_key_id")]
    public Guid ApiKeyId { get; set; }
    [Required]
    [Column("c_uid_correlation_id")]
    public Guid CorrelationId { get; set; }
    [Required]
    [Column("c_jsn_metadata", TypeName = "jsonb")]
    public String Metadata { get; set; }
    [Required]
    [Column("c_tsp_timestamp")]
    public DateTime Timestamp { get; set; }
    [Required]
    [MaxLength(15)]
    [Column("c_str_tracker_ip_address")]
    public String TrackerIpAddress { get; set; }
}