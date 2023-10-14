using Homee.DataAccess.Repository.IRepository;
using Homee.Models.Dto.RoomDTO;
using Homee.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Homee.Web.Controllers;

[Route("room")]
[ApiController]
public class RoomController : ControllerBase
{
    private  ApiResponse _response;
    private readonly IUnitOfWork _unitOfWork;

    public RoomController(IUnitOfWork unitOfWork)
    {
        _response = new ApiResponse();
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> CreateRoomAsync([FromBody] RoomCreateDTO roomCreateDTO)
    {
        try
        {
            if(ModelState.IsValid)
            {
                var newRoom = await _unitOfWork.Rooms.CreateRoomAsync(roomCreateDTO);
                if (newRoom == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Room Created Fail" };

                    return BadRequest(_response);
                }
                _response.Result = newRoom;
                _response.StatusCode = HttpStatusCode.Created;

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
