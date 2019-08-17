using System;
using System.Threading.Tasks;
using Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Implementation;
using PalasProject.Repositories.Interfaces;

namespace PalasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotController : ControllerBase
    {
        private readonly IParkingRepo<ParkingSpot> _parkingSpotRepository;

        public ParkingSpotController(IParkingRepo<ParkingSpot> parkingspotRepository)
        {
            _parkingSpotRepository = parkingspotRepository;
        }

        // GET api/ParkingSpot
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                await _parkingSpotRepository.GetAllAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/ParkingSpot/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var parkingSpot = await _parkingSpotRepository.GetByIdAsync(id);

                if (parkingSpot != null)
                {
                    return Ok();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/ParkingSpot
        [HttpPost]
        public async Task<ActionResult> Post(bool isAvailable)
        {
            var parkingSpot = new ParkingSpot
            {
                IsAvailable = isAvailable
            };

            try
            {
                await _parkingSpotRepository.InsertAsync(parkingSpot);
                await _parkingSpotRepository.SaveAsync();

                return Ok();
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
                var parkingSpotToUpdate = _parkingSpotRepository.UpdateAsync(await _parkingSpotRepository.GetByIdAsync(id));
                parkingSpotToUpdate.IsAvailable = isAvailable;
                await _parkingSpotRepository.SaveAsync();

                return Ok();
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
                await _parkingSpotRepository.DeleteAsync(id);
                await _parkingSpotRepository.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}