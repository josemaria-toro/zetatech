using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_dependencies", Schema = "tracking")]
public class DependencyEntity : BaseTrackingEntity
{
    [MaxLength(4096)]
    [Column("c_str_data_input")]
    public String DataInput { get; set; }
    [MaxLength(4096)]
    [Column("c_str_data_output")]
    public String DataOutput { get; set; }
    [Required]
    [Column("c_dbl_duration")]
    public Double Duration { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
    [Required]
    [Column("c_bln_success")]
    public Boolean Success { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_target")]
    public String Target { get; set; }
    [Required]
    [MaxLength(32)]
    [Column("c_str_type")]
    public String Type { get; set; }
}