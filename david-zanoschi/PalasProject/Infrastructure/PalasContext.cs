using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Models.Models.Implementation;

namespace Infrastructure
{
    public class PalasContext : DbContext
    {
        public PalasContext(DbContextOptions<PalasContext> options) : base(options)
        {

        }

        public DbSet<ParkingLot> ParkingLots { get; set; }

        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkingLotConfiguration());
        }
    }
}
