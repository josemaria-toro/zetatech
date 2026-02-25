using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_traces", Schema = "tracking")]
public class TraceEntity : BaseTrackingEntity
{
    [Required]
    [MaxLength(1024)]
    [Column("c_str_message")]
    public String Message { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_source")]
    public String Source { get; set; }
}
