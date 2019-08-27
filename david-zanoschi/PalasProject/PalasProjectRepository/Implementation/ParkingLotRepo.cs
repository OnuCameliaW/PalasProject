using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Models.Implementation;
using PalasProject.Repositories.Interfaces;
// rename folder to Repositories and file to have  Repository suffix
namespace PalasProject.Repositories.Implementation
{
    public class ParkingLotRepo : IParkingRepo<ParkingLot>
    {
        private readonly PalasContext _context;

        public ParkingLotRepo(PalasContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await _context.ParkingLots.ToListAsync();
        }

        public async Task<ParkingLot> GetByIdAsync(int id)
        {
            return await _context.ParkingLots.FirstOrDefaultAsync(pl => pl.ParkingLotId == id);
        }

        public async Task InsertAsync(ParkingLot parkinglot)
        {
            await _context.ParkingLots.AddAsync(parkinglot);
        }

        public ParkingLot UpdateAsync(ParkingLot parkinglot)
        {
            _context.Entry(parkinglot).State = EntityState.Modified;

            return parkinglot;
        }

        public async Task DeleteAsync(int id)
        {
        // don`t use generics. Use firstorDefault, no avoid errors
            var parkingLotToRemove = await _context.ParkingLots.FindAsync(id);
            // check for null
            _context.Remove(parkingLotToRemove);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
