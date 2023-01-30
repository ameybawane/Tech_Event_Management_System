using Microsoft.AspNetCore.Mvc;
using TEMS.Business.Abstraction;
using TEMS.Business.Entities.ViewModel;

namespace TEMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TalksDetailController : ControllerBase
    {
        ITalksDetail _Repository;
        public TalksDetailController(ITalksDetail talksDetailRepository)
        {
            _Repository = talksDetailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddTalkDet(AddTalksDetail Data)
        {
            try
            {
                await _Repository.AddTalksDetail(Data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
