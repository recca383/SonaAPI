using static SonaAPI.Models.Spotify;

namespace SonaAPI.Models.Spotify
{
    public class Owner
    {
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string display_name { get; set; }
    }
}
