using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    public int DeviceId { get; set; }
    [ForeignKey("DeviceId")]
    public Device Device { get; set; }
    //public int UserId { get; set; }
    public string Type { get; set; }
    public DateTime Timestamp { get; set; }
}
