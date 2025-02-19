using Microsoft.EntityFrameworkCore;
using RoomService.Data.Entities;

namespace RoomService.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<RoomEntity> Rooms { get; set; }
}