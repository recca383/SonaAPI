namespace SonaAPI.Models.Spotify
{
    public class Owner
    {
        public required External_Urls external_urls { get; set; }
        public required string href { get; set; }
        public required string id { get; set; }
        public string? type { get; set; }
        public required string uri { get; set; }
        public string? display_name { get; set; }
    }
}
