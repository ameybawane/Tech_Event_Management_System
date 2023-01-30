using Microsoft.AspNetCore.Mvc;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEvent _Repository;
        public EventController(IEvent eventRepository)
        {
            _Repository = eventRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEveById(int id)
        {
            try
            {
                var result = await _Repository.GetEventById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompEve()
        {
            try
            {
                return Ok(await _Repository.GetAllCompletedEvents());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{month}/{year}")]
        public async Task<IActionResult> GetEveByMonthYear(int month, int year)
        {
            try
            {
                var result = await _Repository.GetAllEventsByMonthYear(month, year);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddEve(EventViewModel Data)
        {
            try
            {
                await _Repository.AddEvent(Data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEve(int id, EventViewModel eve)
        {
            try
            {
                if (eve == null) return BadRequest();
                if (id != eve.Id) return BadRequest();
                await _Repository.UpdateEvent(id, eve);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
