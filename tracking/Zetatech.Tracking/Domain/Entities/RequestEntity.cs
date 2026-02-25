using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_requests", Schema = "tracking")]
public class RequestEntity : BaseTrackingEntity
{
    [MaxLength(8196)]
    [Column("c_str_body")]
    public String Body { get; set; }
    [Required]
    [Column("c_dbl_duration")]
    public Double Duration { get; set; }
    [Required]
    [MaxLength(1024)]
    [Column("c_str_endpoint")]
    public String Endpoint { get; set; }
    [Required]
    [MaxLength(15)]
    [Column("c_str_ip_address")]
    public String IpAddress { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
    [MaxLength(8096)]
    [Column("c_str_response")]
    public String Response { get; set; }
    [Column("c_int_statuscode")]
    public Int32? StatusCode { get; set; }
    [Required]
    [Column("c_bln_success")]
    public Boolean Success { get; set; }
    [Required]
    [MaxLength(32)]
    [Column("c_str_type")]
    public String Type { get; set; }
}
