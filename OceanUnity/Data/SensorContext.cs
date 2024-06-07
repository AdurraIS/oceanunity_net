using Microsoft.EntityFrameworkCore;
using oceanunity.entities;

namespace oceanunity.data;

public class SensorContext: DbContext
{
    public DbSet<Sensor> Sensores {get; set;}

    public SensorContext(DbContextOptions<SensorContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensor>().ToTable("tb_sensor");
    }
}