using Homee.Models;
using Homee.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository.IRepository;

public interface IDeviceRepo : IRepository<Device>
{
    Task<Device> CreateDevicesAsync(DevicesCreateDTO devicesCreateDTO);
    Task<Device> UpdateDevicesAsync(int id, DevicesUpdateDTO devicesUpdateDTO);
    Task<bool> DeleteDevicesAsync(int id);
}
