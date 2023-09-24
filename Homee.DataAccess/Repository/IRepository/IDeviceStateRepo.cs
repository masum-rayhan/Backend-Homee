using Homee.Models;
using Homee.Models.Dto.DeviceStateDTO;

namespace Homee.DataAccess.Repository.IRepository;

public interface IDeviceStateRepo : IRepository<DeviceState>
{
    Task<DeviceState> CreateDevicesStateAsync(DeviceStateCreateDTO deviceStateCreateDTO);
    Task<DeviceState> UpdateDevicesStateAsync(int id, DeviceStateUpdateDTO deviceStateUpdateDTO);
    Task<bool> DeleteDevicesStateAsync(int id);
}
