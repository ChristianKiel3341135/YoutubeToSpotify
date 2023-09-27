using Microsoft.AspNetCore.Mvc;
using YoutubeToSpotify.Services;
using SpotifyAPI.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YoutubeToSpotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISpotifyClient _spotifyClient;
       
        public UserController(ISpotifyClient spotifyClient) {
            
            _spotifyClient = spotifyClient;
        }
        // GET: Test um Token von Spotify API zu erhalten
        [HttpGet]
        public async Task<string> Get()
        {
            var track = await _spotifyClient.Tracks.Get("3rMjvr9Ww1w4SaVrNATO55");
            return track.Name;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"test {id}";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
