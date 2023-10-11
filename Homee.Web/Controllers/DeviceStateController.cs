using Homee.DataAccess.Repository.IRepository;
using Homee.Models.Dto.DeviceStateDTO;
using Homee.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Homee.Web.Controllers
{
    [Route("device-state")]
    [ApiController]
    public class DeviceStateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApiResponse _response;
        public DeviceStateController(IUnitOfWork unitOfWork)
        {
            _response = new ApiResponse();
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeviceState(DeviceStateCreateDTO deviceStateCreateDTO)
        {
            try
            {
                if (deviceStateCreateDTO == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Invalid payload" };

                    return BadRequest(_response);
                }

                var deviceState = await _unitOfWork.DeviceStates.CreateDevicesStateAsync(deviceStateCreateDTO);

                if (deviceState == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Failed to create device state" };

                    return BadRequest(_response);
                }

                _response.Result = deviceState;
                _response.StatusCode = HttpStatusCode.Created;

                //return CreatedAtRoute("GetDeviceState", new { id = deviceState.Id }, _response);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceState(int Id, [FromBody] DeviceStateUpdateDTO deviceStateUpdateDTO)
        {
            try
            {
                if (deviceStateUpdateDTO == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Invalid payload" };

                    return BadRequest(_response);
                }

                var stateToUpdate = await _unitOfWork.DeviceStates.UpdateDevicesStateAsync(Id, deviceStateUpdateDTO);

                if (stateToUpdate == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Failed to update device state" };

                    return BadRequest(_response);
                }
                else
                {
                    _response.Result = stateToUpdate;
                    _response.StatusCode = HttpStatusCode.OK;

                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }
    }
}