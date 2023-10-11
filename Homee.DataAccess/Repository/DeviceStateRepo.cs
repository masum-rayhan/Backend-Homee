using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using Homee.Models;
using Homee.Models.Dto.DeviceStateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository;

public class DeviceStateRepo : Repository<DeviceState>, IDeviceStateRepo
{
    private readonly AppDbContext _db;

    public DeviceStateRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<DeviceState> CreateDevicesStateAsync(DeviceStateCreateDTO deviceStateCreateDTO)
    {
        try
        {
            if (deviceStateCreateDTO == null)
                throw new ArgumentNullException(nameof(deviceStateCreateDTO));

            DeviceState deviceStateToCreate = new DeviceState
            {
                DeviceId = deviceStateCreateDTO.DeviceId,
                StateType = deviceStateCreateDTO.StateType,
                Value = deviceStateCreateDTO.Value
            };
            await _db.DeviceStates.AddAsync(deviceStateToCreate);
            await _db.SaveChangesAsync();

            return deviceStateToCreate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Add New Device State.", ex);
        }
    }

    public async Task<DeviceState> UpdateDevicesStateAsync(int id, DeviceStateUpdateDTO deviceStateUpdateDTO)
    {
        try
        {
            if (deviceStateUpdateDTO == null)
                throw new ArgumentNullException(nameof(deviceStateUpdateDTO));

            var stateToUpdate = await _db.DeviceStates.FindAsync(id);

            if (stateToUpdate == null)
                throw new InvalidOperationException("Device State Not Found.");

            stateToUpdate.StateType = deviceStateUpdateDTO.StateType;
            stateToUpdate.Value = deviceStateUpdateDTO.Value;

            await _db.SaveChangesAsync();
            return stateToUpdate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Update Device State.", ex);
        }
    }

    public Task<bool> DeleteDevicesStateAsync(int id)
    {
        throw new NotImplementedException();
    }

    //public async Task<DeviceState> UpdateDevicesStateAsync(int id, DeviceStateUpdateDTO deviceStateUpdateDTO)
    //{
    //    var device = await _db.Devices.FindAsync(id);
    //    if (device == null)
    //    {
    //        return null;
    //    }
    //    var deviceState = await _db.DeviceStates.FindAsync(deviceStateUpdateDTO.Id);
    //    if (deviceState == null)
    //    {
    //        return null;
    //    }
    //    deviceState.StateType = deviceStateUpdateDTO.StateType;
    //    deviceState.Value = deviceStateUpdateDTO.Value;
    //    await _db.SaveChangesAsync();
    //    return device;
    //}

    //public async Task<bool> DeleteDevicesStateAsync(int id)
    //{
    //    var deviceState = await _db.DeviceStates.FindAsync(id);
    //    if (deviceState == null)
    //    {
    //        return false;
    //    }
    //    _db.DeviceStates.Remove(deviceState);
    //    await _db.SaveChangesAsync();
    //    return true;
    //}
}
