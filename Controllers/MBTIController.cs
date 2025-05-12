using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonaAPI.Repository;

namespace SonaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MBTIController : ControllerBase
    {
        private readonly SpotifyRepository spotifyRepository;

        public MBTIController(SpotifyRepository spotifyRepository)
        {
            this.spotifyRepository = spotifyRepository;
        }

        [HttpGet("{playlistId}")]
        public async Task<IActionResult> GetPlaylist(string playlistId)
        {
            var accessToken = await spotifyRepository.GetAccessTokenAsync();

            var result = await spotifyRepository.GetPlaylist(playlistId, accessToken);

            if(result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
