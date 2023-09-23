using Homee.DataAccess.Repository.IRepository;
using Homee.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
            _response.Result = await _unitOfWork.Device.GetAllAsync();
            _response.StatusCode = System.Net.HttpStatusCode.OK;

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return Ok(_response);
    }
}
