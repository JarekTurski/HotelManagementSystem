using AutoMapper;
using RoomService.Data.Entities;
using RoomService.Data.Models;

namespace RoomService.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RoomEntity, RoomModel>(); 
    }
}
