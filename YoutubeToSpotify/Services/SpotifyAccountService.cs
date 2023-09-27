using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using YoutubeToSpotify.Models;

namespace YoutubeToSpotify.Services
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;
        
        public SpotifyAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSpotifyToken(string clientId, string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                {
                    "grant_type", "client_credentials"
                } 
            });

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var test = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(test);
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<SpotifyAuthenticationResult>(responseStream);

            return authResult.AccessToken;
            
        }
    }
}
