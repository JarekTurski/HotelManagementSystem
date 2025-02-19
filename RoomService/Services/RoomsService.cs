using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RoomService.Data;
using RoomService.Data.Entities;
using RoomService.Data.Models;
using RoomService.Data.Models.Common;
using RoomService.Enums;
using RoomService.Extensions;      
using RoomService.Interfaces;
using System.Collections;
using System.Formats.Asn1;

namespace RoomService.Services;

public class RoomsService(DataContext dataContext, 
    ILogger<RoomsService> logger,
    IMapper mapper) : IRoomService
{
    public async Task<Result<RoomModel>> GetRoom(Guid id)
    {
        var roomResult = await dataContext.Rooms
                .SingleOrDefaultAsync(x => x.Id == id);

        if (roomResult is null)
        {
            return Result.Failure<RoomModel>(ErrorType.NotFound);
        }
        return Result.Success(roomResult.ToRoomModel());
    }

    public async Task<Result<IEnumerable<RoomModel>>> GetRooms(GetRoomsRequestModel request)
    {
        try
        {
            var query = dataContext.Rooms.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(r => r.Name.Contains(request.Name));
            }

            if (request.IsAvailable.HasValue)
            {
                query = query.Where(x => x.IsAvailable() == request.IsAvailable.Value);
            }

            if (request.Size.HasValue)
            {
                query = query.Where(r => r.Size == request.Size.Value);
            }

            query = query
                .Skip(request.PageCount * request.PageSize)
                .Take(request.PageSize);

            var data = await query
                .ProjectTo<RoomModel>(mapper.ConfigurationProvider)
                .ToListAsync() as IEnumerable<RoomModel>;

            return Result.Success(data);
        }
        catch(Exception ex)
        {
            logger.LogInformation($"GetRooms failure. {ex}");
            return Result.Failure<IEnumerable<RoomModel>>(ErrorType.GetRoomsFailed);
        }
    }

    public async Task<Result<RoomModel>> CreateRoom(CreateRoomRequestModel request)
    {
        var roomEntity = RoomEntity.Create(
            new Guid(), 
            request.Name, 
            request.Size);

        await dataContext.Rooms.AddAsync(roomEntity);
        await dataContext.SaveChangesAsync();

        return Result.Success(roomEntity.ToRoomModel());
    }

    public async Task<Result<RoomModel>> UpdateRoom(Guid id, UpdateRoomRequestModel request)
    {
        var roomResult = await dataContext.Rooms
                .SingleOrDefaultAsync(x => x.Id == id);

        if (roomResult is null)
        {
            return Result.Failure<RoomModel>(ErrorType.NotFound);
        }
        try
        {
            if (!roomResult.IsAvailable() 
                && IsRequestModifyingAvailability(request))
            {
                return Result.Failure<RoomModel>(ErrorType.UnavailableRoom);
            }

            roomResult.Update(
                name: request.Name,
                size: request.Size,
                isUnderCleaning: request.IsUnderCleaning,
                isManuallyLocked: request.IsManuallyLocked,
                isOccupied: request.IsOccupied,
                isUnderMaintenance: request.IsUnderMaintenance,
                comment: request.Comment
                );

            await dataContext.SaveChangesAsync();
            return Result.Success(roomResult.ToRoomModel());
        }
        catch (Exception ex)
        {
            logger.LogInformation($"Update room entity failed. {ex}");
            return Result.Failure<RoomModel>(ErrorType.UpdateRoomEntityFailed);
        }
    }

    private bool IsRequestModifyingAvailability(UpdateRoomRequestModel reuqest)
    {
        if (reuqest.IsManuallyLocked.GetValueOrDefault()) 
        { 
            return true; 
        }

        if (reuqest.IsOccupied.GetValueOrDefault())
        {
            return true;
        }

        if (reuqest.IsUnderCleaning.GetValueOrDefault())
        {
            return true;
        }

        if (reuqest.IsUnderMaintenance.GetValueOrDefault())
        {
            return true;
        }

        return false;
    }
}