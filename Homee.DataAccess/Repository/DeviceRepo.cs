using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using Homee.Models;
using Homee.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository;

public class DeviceRepo : Repository<Device>, IDeviceRepo
{
    private readonly AppDbContext _db;
    public DeviceRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Device> CreateDevicesAsync(DevicesCreateDTO devicesCreateDTO)
    {
        try
        {
            if (devicesCreateDTO == null)
            {
                throw new ArgumentNullException(nameof(devicesCreateDTO));
            }

            Device devicesToCreate = new Device
            {
                Name = devicesCreateDTO.Name,
                DeviceType = devicesCreateDTO.DeviceType,
                Location = devicesCreateDTO.Location
            };
            _db.Devices.Add(devicesToCreate);
            await _db.SaveChangesAsync();

            return devicesToCreate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Add New Device.", ex);
        }
    }

    public async Task<Device> UpdateDevicesAsync(int id, DevicesUpdateDTO devicesUpdateDTO)
    {
        try
        {
            if (devicesUpdateDTO == null || id != devicesUpdateDTO.Id)
                throw new ArgumentException(nameof(devicesUpdateDTO));

            Device devicesToUpdate = await _db.Devices.FindAsync(id);

            devicesToUpdate.Name = devicesUpdateDTO.Name;
            devicesToUpdate.DeviceType = devicesUpdateDTO.DeviceType;
            devicesToUpdate.Location = devicesUpdateDTO.Location;

            _db.Devices.Update(devicesToUpdate);
            await _db.SaveChangesAsync();

            return devicesToUpdate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Update Device.", ex);
        }
    }

    public async Task<bool> DeleteDevicesAsync(int id)
    {
        try
        {
            if(id == 0)
                throw new ArgumentException("Invalid data"); 
            
            Device devicesToDelete = await _db.Devices.FindAsync(id);

            _db.Devices.Remove(devicesToDelete);
            await _db.SaveChangesAsync();

            return true;
        } 
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Remove Device.", ex);
        }
    }
}
