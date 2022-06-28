using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using przygotowanie_do_kolokwium.Services;
using System.Threading.Tasks;

namespace przygotowanie_do_kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{IdAlbum}")]
        public async Task<ActionResult> GetAlbums(int IdAlbum) {

            var albums = await _dbService.GetAlbums(IdAlbum);
            return Ok(albums);

        }

    }
}
