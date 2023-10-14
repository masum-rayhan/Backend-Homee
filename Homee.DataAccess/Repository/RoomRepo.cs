using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using Homee.Models;
using Homee.Models.Dto.RoomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository;

public class RoomRepo : Repository<Room>, IRoomRepo
{
    private readonly AppDbContext _db;

    public RoomRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Room> CreateRoomAsync(RoomCreateDTO roomCreateDTO)
    {
        try
        {
            if (roomCreateDTO == null)
                throw new ArgumentNullException(nameof(roomCreateDTO));

            var newRoom = new Room
            {
                RoomName = roomCreateDTO.RoomName
            };

            await _db.Rooms.AddAsync(newRoom);
            await _db.SaveChangesAsync();

            return newRoom;
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't create new room: {ex.Message}");
        }
    }
}
