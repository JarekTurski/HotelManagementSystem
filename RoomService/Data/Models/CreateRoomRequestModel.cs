namespace RoomService.Data.Models;

public class CreateRoomRequestModel
{
    public required string Name { get; set; }
    public required int Size { get; set; }
}
