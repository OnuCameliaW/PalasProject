using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models.Implementation;

namespace Infrastructure.Configurations
{
    public class ParkingLotConfiguration : IEntityTypeConfiguration<ParkingLot>
    {
        public void Configure(EntityTypeBuilder<ParkingLot> builder)
        {
            builder
                .HasMany(pl => pl.ParkingSpots)
                .WithOne(ps => ps.ParkingLot)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
