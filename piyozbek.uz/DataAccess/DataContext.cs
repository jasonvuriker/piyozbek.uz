using Microsoft.EntityFrameworkCore;
using piyozbek.uz.DataAccess.Entities;

namespace piyozbek.uz.DataAccess;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Car> Cars { get; set; }

    public DbSet<Driver> Drivers { get; set; }
}
