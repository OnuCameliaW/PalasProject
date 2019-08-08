using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using PalasProject.Models.Impl;

namespace PalasProject.Repositories
{
    // all methods should have Async suffix
    public class ParkingSpotRepo<T> : IParkingRepo<ParkingSpot>
    {
        private readonly PalasContext _context;

        public ParkingSpotRepo(PalasContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingSpot>> GetAll()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        public async Task<ParkingSpot> GetById(int id)
        {
            return await _context.ParkingSpots.FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task Insert(ParkingSpot parkingSpot)
        {
            await _context.ParkingSpots.AddAsync(parkingSpot);
        }

        public ParkingSpot Update(ParkingSpot parkingSpot)
        {
            _context.Entry(parkingSpot).State = EntityState.Modified;

            return parkingSpot;
        }

        public async Task Delete(int id)
        {
            var parkingSpotToRemove = await _context.ParkingSpots.FindAsync(id);
            _context.Remove(parkingSpotToRemove);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
