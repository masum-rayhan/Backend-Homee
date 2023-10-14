using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.Models.Dto.RoomDTO;

public class RoomCreateDTO
{
    [Required]
    public string RoomName { get; set; }
}
