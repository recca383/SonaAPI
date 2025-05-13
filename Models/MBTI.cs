namespace SonaAPI.Models
{
    public class MBTI
    {
        public required string Mbti { get; set; }
        public required string Function_pair { get; set; }
        public float Danceablitiy { get; set; }
        public float Liveliness { get; set; }
        public float Valance { get; set; }
        public float Energy { get; set; }
        public float Instrumentalness { get; set; }
        public float Loudness { get; set; }
        public float Tempo { get; set; }
    }
}
