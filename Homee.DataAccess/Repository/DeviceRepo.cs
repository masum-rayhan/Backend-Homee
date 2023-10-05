using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using Homee.DataAccess.Utils;
using Homee.Models;
using Homee.Models.Dto.DeviceDTO;
using Homee.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public async Task<Device> CreateDeviceAsync(DeviceCreateDTO deviceCreateDTO)
    {
        try
        {
            if (deviceCreateDTO == null)
                throw new ArgumentNullException(nameof(deviceCreateDTO));

            // Convert the DeviceType string to the corresponding enum value
            if (!Enum.TryParse(deviceCreateDTO.DeviceType, out DeviceType deviceType))
            {
                throw new ArgumentException("Invalid DeviceType.");
            }

            // Get the initial state attributes based on the selected device type
            var (initialDeviceStateType, initialDeviceState, initialValue) = DeviceTypeService.GetInitialDeviceState(deviceType);

            // Create the new Device entity
            var newDevice = new Device
            {
                Name = deviceCreateDTO.Name,
                DeviceType = deviceCreateDTO.DeviceType,
                Location = deviceCreateDTO.Location
            };

            // Create the new DeviceState entity for the initial state
            var newDeviceState = new DeviceState
            {
                StateType = initialDeviceStateType,
                State = initialDeviceState,
                Value = initialValue
            };

            // Associate the DeviceState with the Device
            newDevice.DeviceStates = new List<DeviceState> { newDeviceState };

            // Add both the Device and DeviceState to the database
            _db.Devices.Add(newDevice);
            await _db.SaveChangesAsync();

            return newDevice;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to Add New Device.", ex);
        }
    }

    public async Task<Device> UpdateDevicesAsync(int id, DeviceUpdateDTO devicesUpdateDTO)
    {
        try
        {
            if (devicesUpdateDTO == null || id != devicesUpdateDTO.Id)
                throw new ArgumentException(nameof(devicesUpdateDTO));

            Device devicesToUpdate = await _db.Devices.FindAsync(id);

            devicesToUpdate.Name = devicesUpdateDTO.Name;
            devicesToUpdate.DeviceType = devicesUpdateDTO.DeviceType.ToString(); // Convert enum to string
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
            if (id == 0)
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

    public IEnumerable<DeviceTypeDto> GetDeviceTypes()
    {
        var deviceTypes = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();

        var deviceTypeDtos = deviceTypes.Select(deviceType => new DeviceTypeDto
        {
            Value = deviceType.ToString(),
            DisplayName = GetEnumDisplayName(deviceType)
        });

        return deviceTypeDtos;
    }

    private string GetEnumDisplayName(Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var enumName = enumValue.ToString();

        var displayAttribute = enumType
            .GetField(enumName)
            .GetCustomAttributes(typeof(DisplayAttribute), false)
            .Cast<DisplayAttribute>()
            .SingleOrDefault();

        return displayAttribute?.Name ?? enumName;
    }
}
