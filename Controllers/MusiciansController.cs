using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using przygotowanie_do_kolokwium.Services;
using System.Threading.Tasks;

namespace przygotowanie_do_kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IDbService _dbService;
        public MusiciansController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{IdMusician}")]
        public async Task<IActionResult> DeleteMusician(int IdMusician) {
            var deleted = await _dbService.DeleteMusician(IdMusician);

            if (deleted)
            {
                return Ok("Musician has been deleted");
            }
            else
            {
                return BadRequest("Cannot delete musician");
            }
        }

    }
}
