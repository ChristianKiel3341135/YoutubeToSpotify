using Microsoft.AspNetCore.Mvc;
using YoutubeToSpotify.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YoutubeToSpotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        public UserController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration) {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
        }
        // GET: api/User
        [HttpGet]
        public async Task<string> Get()
        {
            var token = await _spotifyAccountService.GetSpotifyToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
            return token;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"user {id}";
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
