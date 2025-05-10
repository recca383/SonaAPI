
namespace SonaAPI.Models.Spotify
{
    public class Item
    {
        public DateTime? added_at { get; set; }
        public Added_By? added_by { get; set; }
        public bool is_local { get; set; }
        public required Track track { get; set; }
    }
}
