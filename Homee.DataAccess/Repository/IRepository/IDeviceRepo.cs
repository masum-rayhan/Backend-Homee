using Homee.Models;
using Homee.Models.Dto.DeviceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository.IRepository;

public interface IDeviceRepo : IRepository<Device>
{
    Task<Device> CreateDevicesAsync(DeviceCreateDTO devicesCreateDTO);
    Task<Device> UpdateDevicesAsync(int id, DeviceUpdateDTO devicesUpdateDTO);
    Task<bool> DeleteDevicesAsync(int id);
}
