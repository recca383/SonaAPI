using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonaAPI.Models;
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
        public async Task<IActionResult> GetPlaylist([FromBody]MBTI mbti)
        {
            var playlistID = await mbtiRepository.GetPlaylistID(mbti);

            //var accessToken = await spotifyRepository.GetAccessTokenAsync();

            //var result = await spotifyRepository.GetPlaylist(playlistId, accessToken);

            if (playlistID != null)
                return Ok(playlistID);

            return NotFound();
        }
    }
}
