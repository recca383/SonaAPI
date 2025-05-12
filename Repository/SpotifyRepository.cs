using Microsoft.AspNetCore.Http.HttpResults;
using SonaAPI.Models.Spotify;
using SonaAPI.Repository.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SonaAPI.Repository
{
    public class SpotifyRepository : ISpotifyContract
    {
        private readonly HttpClient client;
        private readonly string _clientId = Environment.GetEnvironmentVariable("client_id")!;
        private readonly string _clientSecret = Environment.GetEnvironmentVariable("client_secret")!;
        public SpotifyRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            //Convert Auth into base 64
            var auth = Convert.ToBase64String
                (Encoding.UTF8.GetBytes
                        ($"{_clientId}:{_clientSecret}")
                );

            var request = new HttpRequestMessage
                (HttpMethod.Post, "https://accounts.spotify.com/api/token");

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);
            request.Content = new StringContent
                ("grant_type=client_credentials"
                , Encoding.UTF8
                , "application/x-www-form-urlencoded");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(content);


            return doc.RootElement.GetProperty("access_token").GetString()!;
        }

        public async Task<SpotifyPlaylist> GetPlaylist(string playlistId, string accessToken)
        {
            client.DefaultRequestHeaders.Authorization =
             new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client
                                .GetFromJsonAsync<SpotifyPlaylist>
                                    ($"https://api.spotify.com/v1/playlists/{playlistId}");
            
            return response!;
           
        }

        public Task<Track> GetTrack(int track_number)
        {
            throw new NotImplementedException();
        }
    }
}
