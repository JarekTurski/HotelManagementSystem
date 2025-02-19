namespace RoomService.Data.Models;

public class RoomModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// Max occupancy for a room: 1, 2 or 3 people.
    /// </summary>
    public int Size { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsUnderCleaning { get; set; }
    public bool IsUnderMaintenance { get; set; }
    public bool IsManuallyLocked { get; set; }
    public string? Comment { get; set; }
}
