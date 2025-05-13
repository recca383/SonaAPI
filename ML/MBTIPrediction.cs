using Microsoft.ML.Data;

namespace SonaAPI.ML
{
    public class MBTIPrediction
    {
        [ColumnName("PredictedLabel")]
        public string? playlist_id { get; set; }
    }
}
