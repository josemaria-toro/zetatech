using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zetatech.Tracking.Domain.Entities;

[Table("t_tracking_page_views", Schema = "tracking")]
public class PageViewEntity : BaseTrackingEntity
{
    [Required]
    [MaxLength(256)]
    [Column("c_str_device")]
    public String Device { get; set; }
    [Required]
    [Column("c_dbl_duration")]
    public Double Duration { get; set; }
    [Required]
    [MaxLength(15)]
    [Column("c_str_ip_address")]
    public String IpAddress { get; set; }
    [Required]
    [MaxLength(256)]
    [Column("c_str_name")]
    public String Name { get; set; }
    [MaxLength(1024)]
    [Column("c_str_url")]
    public String Url { get; set; }
    [MaxLength(1024)]
    [Column("c_str_user_agent")]
    public String UserAgent { get; set; }
}
