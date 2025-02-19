using RoomService.Constants;

namespace RoomService.Data.Models;

public class GetRoomsRequestModel
{
    public string? Name { get; set; }
    public bool? IsAvailable { get; set; }
    public int? Size { get; set; }
    public int PageSize { get; set; } = CommonConstants.DefaultPageSize;
    public int PageCount { get; set; } = 0;
}
