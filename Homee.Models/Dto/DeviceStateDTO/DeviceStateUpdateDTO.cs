using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homee.Models.Dto.DeviceStateDTO;

public class DeviceStateUpdateDTO
{
    [Key]
    public int Id { get; set; }
    public int DeviceId { get; set; }
    [ForeignKey("DeviceId")]
    public Device? Device { get; set; }
    public string StateType { get; set; }
    [Required]
    public bool State { get; set; }
    public string Value { get; set; }
}
