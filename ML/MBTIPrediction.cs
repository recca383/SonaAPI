using Microsoft.ML.Data;

namespace SonaAPI.ML
{
    public class MBTIPrediction
    {
        [ColumnName("playlist_id")]
        public string? playlist_id { get; set; }
    }
}
