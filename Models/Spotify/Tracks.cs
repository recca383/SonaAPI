namespace SonaAPI.Models.Spotify
{
    public class Tracks
    {
        public required string href { get; set; }
        public required int limit { get; set; }
        public required string next { get; set; }
        public required int offset { get; set; }
        public required string previous { get; set; }
        public required int total { get; set; }
        public required Item[] items { get; set; }
        public string? type { get; set; }
        public string? uri { get; set; }
    }
}
