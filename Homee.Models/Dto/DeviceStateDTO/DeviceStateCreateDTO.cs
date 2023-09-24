using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.Models.Dto.DeviceStateDTO;

public class DeviceStateCreateDTO
{
    //[Required]
    public int DeviceId { get; set; }
    [ForeignKey("DeviceId")]
    public Device? Device { get; set; }
    public string StateType { get; set; }
    public string Value { get; set; }
}
