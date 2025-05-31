using SonaAPI.HTTP.Response;
using SonaAPI.Models.Spotify;

namespace SonaAPI.Repository.Contracts
{
    public interface ISpotifyContract
    {
        Task<string> GetAccessTokenAsync();
        Task<SpotifyPlaylist> GetPlaylist(string playlistId, string accessToken);
    }
}
