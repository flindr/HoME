using HoMeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoMeAPI.Entities
{
    public class MeasurementsContext : DbContext
    {
        public MeasurementsContext(DbContextOptions<MeasurementsContext> options) : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}