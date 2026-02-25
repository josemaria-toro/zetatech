using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zetatech.Accelerate.Domain.Abstractions;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_api_keys", Schema = "tracking")]
public class ApiKeyEntity : BaseEntity
{
    [Required]
    [Column("c_bln_enabled")]
    public Boolean Enabled { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
}