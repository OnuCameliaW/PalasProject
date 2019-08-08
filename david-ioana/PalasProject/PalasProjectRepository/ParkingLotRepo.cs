using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using PalasProject.Models.Impl;

namespace PalasProject.Repositories
{
    public class ParkingLotRepo<T> : IParkingRepo<ParkingLot>
    {
        private readonly PalasContext _context;

        public ParkingLotRepo(PalasContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingLot>> GetAll()
        {
            return await _context.ParkingLots.ToListAsync();
        }

        public async Task<ParkingLot> GetById(int id)
        {
            return await _context.ParkingLots.FirstOrDefaultAsync(pl => pl.ParkingLotId == id);
        }

        public async Task Insert(ParkingLot parkingLot)
        {
            await _context.ParkingLots.AddAsync(parkingLot);
        }

        public ParkingLot Update(ParkingLot parkingLot)
        {
            _context.Entry(parkingLot).State = EntityState.Modified;

            return parkingLot;
        }

        public async Task Delete(int id)
        {
            var parkingLotToRemove = await _context.ParkingLots.FindAsync(id);
            _context.Remove(parkingLotToRemove);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
