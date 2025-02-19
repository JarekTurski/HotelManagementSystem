namespace RoomService.Data.Models;

public class UpdateRoomRequestModel
{
    public string? Name { get; set; }
    public int? Size { get; set; }
    public bool? IsOccupied { get; set; }
    public bool? IsUnderCleaning { get; set; }
    public bool? IsUnderMaintenance { get; set; }
    public bool? IsManuallyLocked { get; set; }
    public string? Comment { get; set; }
}
