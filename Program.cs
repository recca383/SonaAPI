
using Microsoft.EntityFrameworkCore;
using SonaAPI.Data;
using SonaAPI.Models.Spotify;
using SonaAPI.Repository;
using SonaAPI.Repository.Contracts;

namespace SonaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            DotNetEnv.Env.Load();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MBTIDataContext>(o=>
            {
                o.UseNpgsql(Environment.GetEnvironmentVariable("MBTIDbContext"));
            });

            builder.Services.AddScoped<ISpotifyContract,SpotifyRepository>();

            builder.Services.AddHttpClient<SpotifyRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
