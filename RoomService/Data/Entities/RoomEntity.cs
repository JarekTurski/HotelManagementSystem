namespace RoomService.Data.Entities;

public class RoomEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsUnderCleaning { get; set; }
    public bool IsUnderMaintenance { get; set; }
    public bool IsManuallyLocked { get; set; }
    public string? Comment { get; set; }

    #region private
    private RoomEntity(Guid id, string name, int size)
    {
        Id = id;
        Name = name;
        Size = size;
    }

    #endregion private

    public static RoomEntity Create(
        Guid id, 
        string name, 
        int size) => 
            new RoomEntity(id, name, size);

    public RoomEntity Update(
        string? name,
        int? size,
        bool? isOccupied,
        bool? isUnderCleaning,
        bool? isUnderMaintenance,
        bool? isManuallyLocked,
        string? comment)
    {
        if(!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if(size != null)
        {
            Size = size.Value;
        }

        if(isOccupied != null)
        {
            IsOccupied = isOccupied.Value;
        }

        if (isUnderCleaning != null)
        {
            IsUnderCleaning = isUnderCleaning.Value;
        }

        if (isUnderMaintenance != null)
        {
            IsUnderMaintenance = isUnderMaintenance.Value;
        }

        if (isManuallyLocked != null)
        {
            IsManuallyLocked = isManuallyLocked.Value;
        }

        if (!string.IsNullOrEmpty(comment))
        {
            Comment = comment;
        }

        return this;
    }

    public void Book()
    {
        IsOccupied = true;
    }

    public void Unbook()
    {
        IsOccupied = false;
    }

    public void CleaningStart()
    {
        IsUnderCleaning = true;
    }

    public void CleaningComplete()
    {
        IsUnderCleaning = false;
    }

    public void MaintenanceStart()
    {
        IsUnderMaintenance = true;
    }

    public void MaintenanceComplete()
    {
        IsUnderMaintenance = false;
    }

    public void ManualLockOn()
    {
        IsManuallyLocked = true;
    }

    public void ManualLockOff()
    {
        IsManuallyLocked = false;
    }

    public bool IsAvailable() => 
        !IsOccupied && !IsUnderCleaning && !IsUnderMaintenance && !IsManuallyLocked;
    
}