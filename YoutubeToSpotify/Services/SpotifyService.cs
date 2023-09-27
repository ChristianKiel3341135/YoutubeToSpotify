using YoutubeToSpotify.Models;

namespace YoutubeToSpotify.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;
        public SpotifyService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task CreatePlaylist(string accesToken){
           
        }
    }
}
