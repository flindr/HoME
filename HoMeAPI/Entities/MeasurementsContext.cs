using Microsoft.EntityFrameworkCore;

namespace HoMeAPI.Entities
{
    public sealed class MeasurementsContext : DbContext
    {
        public MeasurementsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<ClimateMeasurement> ClimateMeasurements { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
    }
}