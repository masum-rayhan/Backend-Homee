using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homee.Models.Dto.DeviceStateDTO;

public class DeviceStateUpdateDTO
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int DeviceId { get; set; }
    [ForeignKey("DeviceId")]
    public Device Device { get; set; }
    public string StateType { get; set; }
    public string Value { get; set; }
}
