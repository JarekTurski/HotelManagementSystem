using RoomService.Data.Entities;
using RoomService.Data.Models;
using RoomService.Data.Models.Common;

namespace RoomService.Interfaces;

public interface IRoomService
{
    Task<Result<RoomModel>> GetRoom(Guid id);
    Task<Result<IEnumerable<RoomModel>>> GetRooms(GetRoomsRequestModel request);
    Task<Result<RoomModel>> CreateRoom(CreateRoomRequestModel request);
    Task<Result<RoomModel>> UpdateRoom(Guid id, UpdateRoomRequestModel request);
}