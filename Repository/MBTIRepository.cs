using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using SonaAPI.ML;
using SonaAPI.Models;
using SonaAPI.Repository.Contracts;
using System.Data;
using System.Linq.Expressions;

namespace SonaAPI.Repository
{
    public class MBTIRepository : IMBTIContract
    {
        public Task<string> GetPlaylistID(MBTI mbti)
        {
            var context = new MLContext();
            string filename = mbti.Mbti.Trim().ToUpper() +"_df.csv";

            var data = context.Data.LoadFromTextFile<MBTIColumns>
                ($"Dataset/{filename}"
                , separatorChar: ','
                , hasHeader: true);

            string[] columns = {"Label"
                                ,"danceability_mean"
                                , "liveness_mean"
                                , "valence_mean"
                                , "energy_mean"
                                , "instrumentalness_mean"
                                , "loudness_mean"
                                , "tempo_mean"
                                , };

            var pipeline =
                    context.Transforms
                .SelectColumns(columns)
                .Append(context.Transforms.Conversion.MapValueToKey("Label"))
                .Append(context.Transforms.Concatenate("Features"
                                                      , columns[1..]
                                                      ))
                .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);

            var predictor = context.Model.CreatePredictionEngine<MBTIColumns, MBTIPrediction>(model);

            MBTIColumns topredict = new MBTIColumns()
            {
                MBTI = mbti.Mbti,
                function_pair = mbti.Function_pair,
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
