using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_metrics", Schema = "tracking")]
public class MetricEntity : BaseTrackingEntity
{
    [Required]
    [MaxLength(256)]
    [Column("c_str_dimension")]
    public String Dimension { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
    [Required]
    [Column("c_dbl_value")]
    public Double Value { get; set; }
}
