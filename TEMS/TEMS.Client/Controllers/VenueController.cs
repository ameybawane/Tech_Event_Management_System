using Microsoft.AspNetCore.Mvc;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Client.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        IVenue _Repository;
        public VenueController(IVenue venueRepository)
        {
            _Repository = venueRepository;
        }

        [HttpPost("Venue/[action]")]
        public async Task<IActionResult> AddVen(VenueViewModel Data)
        {
            try
            {
                await _Repository.AddVenue(Data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Events/{id}/Venues")]
        public async Task<IActionResult> GetVenueOfevents(int id)
        {
            try
            {
                var result = await _Repository.GetVenueOfSpecificEvent(id);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
