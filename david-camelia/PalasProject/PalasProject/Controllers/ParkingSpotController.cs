using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PalasProject.Models.Impl;
using PalasProject.Repositories;
//remove unused references
namespace PalasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotController : ControllerBase
    {
        //this is copy-paste with the other one. Follow all the indications from there
        private readonly IParkingRepo<ParkingSpot> _repo;

        public ParkingSpotController(IParkingRepo<ParkingSpot> repo)
        {
            _repo = repo;
        }

        // GET api/ParkingSpot
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var parkingSpots = await _repo.GetAll();

                return Ok(parkingSpots);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/ParkingSpot/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/ParkingSpot
        [HttpPost]
        public async Task<ActionResult> Post(bool isAvailable)
        {
            ParkingSpot parkingSpot;

            parkingSpot = new ParkingSpot
            {
                IsAvailable = isAvailable
            };

            try
            {
                await _repo.Insert(parkingSpot);
                await _repo.Save();

                return Ok(parkingSpot);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/ParkingSpot/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, bool isAvailable)
        {
            try
            {
                var parkingSpotToUpdate = _repo.Update(await _repo.GetById(id));
                parkingSpotToUpdate.IsAvailable = isAvailable;
                await _repo.Save();

                return Ok(parkingSpotToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/ParkingSpot/5
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