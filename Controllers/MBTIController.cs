using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonaAPI.HTTP.Request;
using SonaAPI.Repository;
using SonaAPI.Repository.Contracts;

namespace SonaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MBTIController : ControllerBase
    {
        private readonly ISpotifyContract spotifyRepository;
        private readonly IMBTIContract mbtiRepository;

        public MBTIController(ISpotifyContract spotifyRepository
                            , IMBTIContract mbtiRepository)
        {
            this.spotifyRepository = spotifyRepository;
            this.mbtiRepository = mbtiRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetPlaylist([FromBody]MBTIRequest mbti)
        {
            var playlistID = await mbtiRepository.GetPlaylistID(mbti);

            var accessToken = await spotifyRepository.GetAccessTokenAsync();

            var result = await spotifyRepository.GetPlaylist(playlistID, accessToken);

            if(result is null)
                return NotFound();


            return Ok(result);

            
        }
    }
}
