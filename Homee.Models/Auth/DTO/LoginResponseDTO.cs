using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.Models.Auth.DTO;

public class LoginResponseDTO
{
    public string Token { get; set; }
    public string Email { get; set; }
}
