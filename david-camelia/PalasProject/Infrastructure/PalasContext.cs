using System;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using PalasProject.Models.Impl;

namespace Infrastructure
{
    public class PalasContext : DbContext
    {
        public PalasContext(DbContextOptions<PalasContext> options) : base(options)
        {

        }

        public DbSet<ParkingLot> ParkingLots { get; set; }
        //add empty line
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkingLotConfiguration());
        }
    }
}
