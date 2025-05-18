namespace SonaAPI.HTTP.Request
{
    public class MBTIRequest
    {
        public required string Mbti { get; set; }
        public float Danceablitiy { get; set; }
        public float Liveliness { get; set; }
        public float Valance { get; set; }
        public float Energy { get; set; }
        public float Instrumentalness { get; set; }
        public float Loudness { get; set; }
        public float Tempo { get; set; }
    }
}
