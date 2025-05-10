
namespace SonaAPI.Models.Spotify
{
    public class Album
    {
        public required string album_type { get; set; }
        public required int total_tracks { get; set; }
        public string[] available_markets { get; set; } = [];
        public required External_Urls external_urls { get; set; }
        public required string href { get; set; }
        public required string id { get; set; }
        public required Image[] images { get; set; }
        public required string name { get; set; }
        public required string release_date { get; set; }
        public required string release_date_precision { get; set; }
        public Restrictions? restrictions { get; set; }
        public required string type { get; set; }
        public required string uri { get; set; }
        public required Artist[] artists { get; set; }
    }
}
