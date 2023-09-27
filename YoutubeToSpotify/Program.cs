using YoutubeToSpotify.Services;
using SpotifyAPI.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISpotifyClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    var config = SpotifyClientConfig
    .CreateDefault()
    .WithAuthenticator(new ClientCredentialsAuthenticator
    (configuration["Spotify:ClientId"], configuration["Spotify:ClientSecret"]));
  
    return new SpotifyClient(config);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
