using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models.Models.Implementation;
using PalasProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PalasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingRepo<ParkingLot> _parkingLotRepository;

        public ParkingLotController(IParkingRepo<ParkingLot> lotRepository)
        {
            _parkingLotRepository = lotRepository;
        }

        // GET api/ParkingLot
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                //var parkingLots = 
                await _parkingLotRepository.GetAllAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/ParkingLot/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                // var parkingLot = 
                await _parkingLotRepository.GetByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/ParkingLot
        [HttpPost]
        public async Task<ActionResult> Post(string numberOfParkingSpots, bool isOpen, string floor, string description)
        {
            if (!Regex.IsMatch(floor.Trim(), @"^[A-Z]\-\d$"))
            {
                // returneaza eroare si logheaz-o
                return BadRequest(@"Floor must match [A-Z]\-[0-9].");
            }

            var parkingLot = new ParkingLot(numberOfParkingSpots, isOpen, floor, description);

            try
            {
                await _parkingLotRepository.InsertAsync(parkingLot);
                await _parkingLotRepository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static void UpdateParkingLot(string numberOfParkingSpots, bool isOpen, string floor, string description,
            ParkingLot lotToUpdate)
        {
            lotToUpdate.NumberOfParkingSpots = numberOfParkingSpots;
            lotToUpdate.IsOpen = isOpen;
            lotToUpdate.Floor = floor;
            lotToUpdate.Description = description;
        }

        // PUT api/ParkingLot/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, string numberOfParkingSpots, bool isOpen, string floor, string description)
        {
            if (!Regex.IsMatch(floor.Trim(), @"[A-Z]\-[0-9]"))
            {
                return BadRequest(@"Floor must match [A-Z]\-[0-9]");
            }

            try
            {
                var parkingLotToUpdate = _parkingLotRepository.UpdateAsync(await _parkingLotRepository.GetByIdAsync(id));
                UpdateParkingLot(numberOfParkingSpots, isOpen, floor, description, parkingLotToUpdate);
                await _parkingLotRepository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/ParkingLot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _parkingLotRepository.DeleteAsync(id);
                await _parkingLotRepository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}