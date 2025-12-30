using DotNetEnv;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddHttpClient();

var app = builder.Build();

string unsplashApiKey = Environment.GetEnvironmentVariable("API_KEY");

app.UseHttpsRedirection();


app.MapGet("/randomphoto", async (HttpClient httpClient) =>
{

    if (string.IsNullOrEmpty(unsplashApiKey))
    {
        return Results.Problem("Api key is missing.");
    }

    string url = $"https://api.unsplash.com/photos/random?client_id={unsplashApiKey}";

    try
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();

            var photo = JsonSerializer.Deserialize<UnsplashPhoto>(responseData);

            if (photo != null && photo.Urls != null) 
            {
                return Results.Ok(new { photoUrl = photo.Urls.Regular });
            }
            return Results.NotFound("No photo found");
        }
        else
        {
            return Results.Problem("Error fetching data from unsplash", statusCode: (int)response.StatusCode);
        }
    }
    catch (HttpRequestException ex)
    {
        return Results.Problem($"Request error: {ex.Message}", statusCode: 500);
    }
});

app.Run();

public class UnsplashPhoto
{
    [JsonPropertyName("urls")]
    public PhotoUrls Urls { get; set; }

    public class PhotoUrls
    {
        [JsonPropertyName("regular")]
        public string Regular { get; set; }
    }
}
