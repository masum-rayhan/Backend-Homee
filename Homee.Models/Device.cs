using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public ICollection<DeviceState>? DeviceStates { get; set; }
}
