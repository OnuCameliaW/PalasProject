using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Models.Implementation;
using PalasProject.Repositories.Interfaces;

namespace PalasProject.Repositories.Implementation
{
    public class ParkingSpotRepo : IParkingRepo<ParkingSpot>
    {
        private readonly PalasContext _context;

        public ParkingSpotRepo(PalasContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingSpot>> GetAllAsync()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        public async Task<ParkingSpot> GetByIdAsync(int id)
        {
            return await _context.ParkingSpots.FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task InsertAsync(ParkingSpot lot)
        {
            await _context.ParkingSpots.AddAsync(lot);
        }

        public ParkingSpot UpdateAsync(ParkingSpot lot)
        {
            _context.Entry(lot).State = EntityState.Modified;

            return lot;
        }

        public async Task DeleteAsync(int id)
        {
            var parkingSpotToRemove = await _context.ParkingSpots.FindAsync(id);
            _context.Remove(parkingSpotToRemove);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
