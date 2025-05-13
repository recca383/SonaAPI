using Microsoft.ML.Data;

namespace SonaAPI.ML
{
    public class MBTIColumns
    {
        // Playlist ID
        [LoadColumn(3)]
        public string? Label { get; set; }
        // MBTI 4 letter Code 
        [LoadColumn(0)]
        public required string MBTI { get; set; }

        [LoadColumn(1)]
        public required string function_pair { get; set; }

        [LoadColumn(5)]
        public float danceability_mean { get; set; }

        [LoadColumn(17)]
        public float liveness_mean { get; set; }

        [LoadColumn(19)]
        public float valence_mean { get; set; }

        [LoadColumn(7)]
        public float energy_mean { get; set; }

        [LoadColumn(23)]
        public float instrumentalness_mean { get; set; }

        [LoadColumn(9)]
        public float loudness_mean { get; set; }

        [LoadColumn(21)]
        public float tempo_mean { get; set; }

        
    }
}
