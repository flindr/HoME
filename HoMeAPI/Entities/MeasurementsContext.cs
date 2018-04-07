using Microsoft.EntityFrameworkCore;

namespace HoMeAPI.Entities
{
    public sealed class MeasurementsContext : DbContext
    {
        public MeasurementsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}