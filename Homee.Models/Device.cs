using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Homee.Models;

public class Device
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string DeviceType { get; set; }
    public string Location { get; set; }
    public int RoomId { get; set; }
    [ForeignKey("RoomId")]
    public Room? Room { get; set; }
    public virtual ICollection<DeviceState>? DeviceStates { get; set; }
}
