using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_tests", Schema = "tracking")]
public class TestEntity : BaseTrackingEntity
{
    [Required]
    [Column("c_dbl_duration")]
    public Double Duration { get; set; }
    [Required]
    [MaxLength(1024)]
    [Column("c_str_message")]
    public String Message { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
    [Required]
    [Column("c_bln_success")]
    public Boolean Success { get; set; }
}
