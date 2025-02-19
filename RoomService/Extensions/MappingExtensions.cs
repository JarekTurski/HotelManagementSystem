using RoomService.Data.Entities;
using RoomService.Data.Models;

namespace RoomService.Extensions;

public static class MappingExtensions
{
    public static IEnumerable<RoomModel> ToRoomModels(this  IEnumerable<RoomEntity> rooms) =>
        rooms.Select(r => r.ToRoomModel());

    public static IQueryable<RoomModel> ToRoomModels(this IQueryable<RoomEntity> rooms) =>
        rooms.Select(r => r.ToRoomModel());

    public static RoomModel ToRoomModel(this RoomEntity entity) =>
        new()
        {
            Comment = entity.Comment,
            Id = entity.Id,
            IsManuallyLocked = entity.IsManuallyLocked,
            IsOccupied = entity.IsOccupied,
            IsUnderCleaning = entity.IsUnderCleaning,
            IsUnderMaintenance = entity.IsUnderMaintenance,
            Name = entity.Name,
            Size = entity.Size,
        };
}
