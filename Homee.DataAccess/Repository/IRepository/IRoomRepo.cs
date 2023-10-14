using Homee.Models;
using Homee.Models.Dto.RoomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository.IRepository;

public interface IRoomRepo : IRepository<Room>
{
    Task<Room> CreateRoomAsync(RoomCreateDTO roomCreateDTO);
}
