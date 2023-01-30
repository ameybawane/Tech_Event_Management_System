using Microsoft.AspNetCore.Mvc;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Client.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        ISpeaker _Repository;
        public SpeakerController(ISpeaker speakerRepository)
        {
            _Repository = speakerRepository;
        }

        [HttpPost("Speaker/[action]")]
        public async Task<IActionResult> AddSpeak(SpeakerViewModel Data)
        {
            try
            {
                await _Repository.AddSpeaker(Data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Speaker/{id}")]
        public async Task<IActionResult> GetSpeakById(int id)
        {
            try
            {
                var result = await _Repository.GetSpeakerById(id);
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

        [HttpGet("Events/{id}/Speakers")]
        public async Task<IActionResult> GetSpeakOfSpecificEve(int id)
        {
            try
            {
                var result = await _Repository.GetSpeakersOfSpecificEvent(id);
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

        [HttpGet("Events/{EventId}/Speakers/{SpeakerId}/Talks")]
        public async Task<IActionResult> GetTalksBySpeakForSpecificEve(int EventId, int SpeakerId)
        {
            try
            {
                var result = await _Repository.GetTalksBySpeakerForSpecificEvent(EventId, SpeakerId);
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
