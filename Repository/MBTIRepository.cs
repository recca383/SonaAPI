using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using SonaAPI.ML;
using SonaAPI.Models;
using SonaAPI.Repository.Contracts;
using System.Data;

namespace SonaAPI.Repository
{
    public class MBTIRepository : IMBTIContract
    {
        public Task<string> GetPlaylistID(MBTI mbti)
        {
            var context = new MLContext();

            var data = context.Data.LoadFromEnumerable(new List<MBTI>());


            switch (mbti.Mbti)
            {
                case:
            }
            var data = context.Data.LoadFromTextFile<MBTIColumns>
                ("Dataset/combined_mbti_df.csv"
                , separatorChar: ','
                , hasHeader: true);

            var pipeline =
                    context.Transforms
                .SelectColumns("danceability_mean", "liveness_mean", "Label")
                .Append(context.Transforms.Conversion.MapValueToKey("Label"))
                .Append(context.Transforms.Concatenate( "Features"
                                                      , "danceability_mean"
                                                      , "liveness_mean"
                                                      ))
                .Append(context.MulticlassClassification.Trainers.SdcaNonCalibrated())
                .Append(context.Transforms.ProjectToPrincipalComponents("Features", rank: 10))
                .Append(context.Transforms.Conversion.MapKeyToValue("Label"));

            var model = pipeline.Fit(data);

            var predictor = context.Model.CreatePredictionEngine<MBTIColumns, MBTIPrediction>(model);

            MBTIColumns topredict = new MBTIColumns()
            {
                Label = mbti.Mbti,
                danceability_mean = mbti.Danceablitiy,
                liveness_mean = mbti.Liveliness,
                valence_mean = mbti.Valance,
                energy_mean = mbti.Energy,
                instrumentalness_mean = mbti.Instrumentalness,
                loudness_mean = mbti.Loudness,
                tempo_mean = mbti.Tempo
            };

            var prediction = predictor.Predict(topredict);

            return Task.FromResult(prediction.playlist_id!);
        }
    }
}
