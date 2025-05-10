
namespace SonaAPI.Models.Spotify
{
    public class SpotifyPlaylist
    {
        public bool collaborative { get; set; }
        public string? description { get; set; }
        public required External_Urls external_urls { get; set; }
        public string? href { get; set; }
        public string? id { get; set; }
        public Image[] images { get; set; } = [];
        public required string name { get; set; }
        public required Owner owner { get; set; }
        public bool _public { get; set; }
        public string? snapshot_id { get; set; }
        public Tracks? tracks { get; set; }
        public string? type { get; set; }
        public string? uri { get; set; }
    }
    
}
