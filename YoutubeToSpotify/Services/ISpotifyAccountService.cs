namespace YoutubeToSpotify.Services
{
    public interface ISpotifyAccountService
    {
        Task<string> GetSpotifyToken(string clientId, string clientSecret);
    }
}
