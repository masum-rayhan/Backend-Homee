using Homee.DataAccess.Repository.IRepository;
using Homee.Models.Dto.DeviceDTO;
using Homee.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Homee.Web.Controllers;

[Route("device")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private ApiResponse _response;
    public DeviceController(IUnitOfWork unitOfWork)
    {
        _response = new ApiResponse();
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetDevices()
    {
        try
        {
            //var includedProperties = "DeviceStates";
            _response.Result = await _unitOfWork.Devices.GetAllAsync(includeProperties: "DeviceStates");
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return Ok(_response);
    }

    [HttpGet("{id:int}", Name = "GetDevices")]
    public async Task<ActionResult<ApiResponse>> GetDevices(int id)
    {
        try
        {
            var device = await _unitOfWork.Devices.GetDetailsAsync(id);

            if (device == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages = new List<string> { "Device not found" };

                return NotFound(_response);
            }

            _response.Result = device;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return Ok(_response);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> CreateDevices([FromBody] DeviceCreateDTO devicesCreateDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var createdDevice = await _unitOfWork.Devices.CreateDevicesAsync(devicesCreateDTO);

                if(createdDevice != null)
                {
                    _response.Result = createdDevice;
                    _response.StatusCode = HttpStatusCode.Created;

                    return CreatedAtRoute("GetDevices", new{ id = createdDevice.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Device could not be created" };

                    return BadRequest(_response);
                }
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return Ok(_response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateDevice(int id, [FromForm] DeviceUpdateDTO devicesUpdateDTO)
    {
        try
        {
            if(ModelState.IsValid)
            {
                var updatedDevice = await _unitOfWork.Devices.UpdateDevicesAsync(id, devicesUpdateDTO);

                if(updatedDevice != null)
                {
                    _response.Result = updatedDevice;
                    _response.StatusCode = HttpStatusCode.OK;

                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Device could not be updated" };

                    return BadRequest(_response);
                }
            }
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }

        return Ok(_response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteDevice(int id)
    {
        try
        {
            var deletedDevice = await _unitOfWork.Devices.DeleteDevicesAsync(id);

            if(deletedDevice != null)
            {
                _response.Result = deletedDevice;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "Device could not be deleted" };

                return BadRequest(_response);
            }
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }

        return Ok(_response);
    }

    [HttpGet("device-types")]
    public IActionResult GetDeviceTypes()
    {
        try
        {
            var deviceTypes = _unitOfWork.Devices.GetDeviceTypes();

            if (deviceTypes != null)
            {
                _response.Result = deviceTypes;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages = new List<string> { "Device types not found" };

                return NotFound(_response);
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return Ok(_response);
    }
}
