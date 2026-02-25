using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_events", Schema = "tracking")]
public class EventEntity : BaseTrackingEntity
{
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
}
