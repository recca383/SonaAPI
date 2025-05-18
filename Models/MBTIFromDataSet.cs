using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SonaAPI.Models
{
    [Table("MBTI_DataSet")]

    public class MBTIFromDataSet
    { 
        [Key]
        public int Id { get; set; }

        public required string Mbti { get; set; }
        public required string FunctionPair { get; set; }
        public string? PlaylistName { get; set; }
        public string? PlaylistId { get; set; }
        public int TrackCount { get; set; }

        public double DanceabilityMean { get; set; }
        public double DanceabilityStdev { get; set; }
        public double EnergyMean { get; set; }
        public double EnergyStdev { get; set; }
        public double LoudnessMean { get; set; }
        public double LoudnessStdev { get; set; }
        public double ModeMean { get; set; }
        public double ModeStdev { get; set; }
        public double SpeechinessMean { get; set; }
        public double SpeechinessStdev { get; set; }
        public double AcousticnessMean { get; set; }
        public double AcousticnessStdev { get; set; }
        public double LivenessMean { get; set; }
        public double LivenessStdev { get; set; }
        public double ValenceMean { get; set; }
        public double ValenceStdev { get; set; }
        public double TempoMean { get; set; }
        public double TempoStdev { get; set; }
        public double InstrumentalnessMean { get; set; }
        public double InstrumentalnessStdev { get; set; }

        public double CminorCount { get; set; }
        public double CMajorCount { get; set; }
        public double CSharpDbMinorCount { get; set; }
        public double CSharpDbMajorCount { get; set; }
        public double DminorCount { get; set; }
        public double DMajorCount { get; set; }
        public double DSharpEbMinorCount { get; set; }
        public double DSharpEbMajorCount { get; set; }
        public double EminorCount { get; set; }
        public double EMajorCount { get; set; }
        public double FMajorCount { get; set; }
        public double FSharpGbMinorCount { get; set; }
        public double GminorCount { get; set; }
        public double GMajorCount { get; set; }
        public double GSharpAbMinorCount { get; set; }
        public double GSharpAbMajorCount { get; set; }
        public double AminorCount { get; set; }
        public double AMajorCount { get; set; }
        public double ASharpBbMajorCount { get; set; }
        public double BMajorCount { get; set; }
        public double FminorCount { get; set; }
        public double FSharpGbMajorCount { get; set; }
        public double ASharpBbMinorCount { get; set; }
        public double BminorCount { get; set; }
    

    }
}
