using SonaAPI.Models;

namespace SonaAPI.Repository.Contracts
{
    public interface IMBTIContract
    {
        Task<string> GetPlaylistID(MBTI mbti);
    }
}
