using SonaAPI.HTTP.Request;

namespace SonaAPI.Repository.Contracts
{
    public interface IMBTIContract
    {
        Task<string> GetPlaylistID(MBTIRequest mbti);
    }
}
