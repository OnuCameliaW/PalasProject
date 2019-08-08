using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PalasProject.Models.Impl;
//remove useless references
namespace PalasProject.Controllers
{
    //get using out of here
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using PalasProject.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingRepo<ParkingLot> _repo;

        public ParkingLotController(IParkingRepo<ParkingLot> repo)
        {
            _repo = repo;
        }

        // GET api/ParkingLot
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var parkingLots = await _repo.GetAll();

                return Ok(parkingLots);
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
                // for easier readability, add this results into a separate variable
                return Ok(await _repo.GetById(id));
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
            ParkingLot parkingLot;
            //use Resharper, it suggested you tu invert if, and it is easier to read
            if (Regex.IsMatch(floor.Trim(), @"^[A-Z]\-\d$"))
            {
                //use contructor
                parkingLot = new ParkingLot
                {
                    NumberOfParkingSpots = numberOfParkingSpots,
                    IsOpen = isOpen,
                    Floor = floor,
                    Description = description
                };

                try
                {
                    // all methods that are async, should be named with Async suffix
                    await _repo.Insert(parkingLot);
                    await _repo.Save();
                    // why do you want to return the same object that you inserted?
                    return new OkObjectResult(parkingLot);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            //add this to resource file
            return BadRequest(@"Floor must match [A-Z]\-[0-9].");
        }

        // PUT api/ParkingLot/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, string numberOfParkingSpots, bool isOpen, string floor, string description)
        {
            //same as above
            if (Regex.IsMatch(floor.Trim(), @"[A-Z]\-[0-9]"))
            {
                try
                {
                    //same
                    var parkingLotToUpdate = _repo.Update(await _repo.GetById(id));
                    // extract this into a separate method, it is hard to read this method
                    parkingLotToUpdate.NumberOfParkingSpots = numberOfParkingSpots;
                    parkingLotToUpdate.IsOpen = isOpen;
                    parkingLotToUpdate.Floor = floor;
                    parkingLotToUpdate.Description = description;
                    await _repo.Save();

                    return Ok(parkingLotToUpdate);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest(@"Floor must match [A-Z]\-[0-9]");
        }

        // DELETE api/ParkingLot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repo.Delete(id);
                await _repo.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}