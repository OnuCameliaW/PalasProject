using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalasProject.Models.Impl;

namespace Infrastructure.Configurations
{
    public class ParkingLotConfiguration : IEntityTypeConfiguration<ParkingLot>
    {
        public void Configure(EntityTypeBuilder<ParkingLot> builder)
        {
            builder
                .HasMany<ParkingSpot>(pl => pl.ParkingSpots)
                .WithOne(ps => ps.ParkingLot)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
