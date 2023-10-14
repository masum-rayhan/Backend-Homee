﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.Models;

public class Room
{
    [Key]
    public int Id { get; set; }
    public string RoomName { get; set; }
    //public virtual ICollection<Device>? Devices { get; set; }
}
