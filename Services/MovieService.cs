using System.Net.Http.Json;
using Yamine.Shared.TheMovie;

namespace Yamine.Services;

public class MovieService(HttpClient http, IConfiguration config) : IMovieService
{
    public async Task<HttpResponseMessage> AuthenticateAsync()
    {
        return await http.GetAsync("authentication");
    }


    public async Task<MovieResponse> GetPopulars(int page)
    {
        var parameters = new Dictionary<string, string>()
            {
                { "language", "ko-kr" },
                { "page", $"{page}" }
        };

        return await http.GetFromJsonAsync<MovieResponse>("movie/popular?" + await new FormUrlEncodedContent(parameters).ReadAsStringAsync());
    }


    public async Task<NowPlaying> GetNowPlaying(int page)
    {
        return await GetData<NowPlaying>("now_playing", page);
    }

    private async Task<T> GetData<T>(string method, int page)
    {
        var parameters = new Dictionary<string, string>()
            {
                { "language", "ko-kr" },
                { "page", $"{page}" }
        };

        return await http.GetFromJsonAsync<T>($"movie/{method}?" + await new FormUrlEncodedContent(parameters).ReadAsStringAsync());
    }
}


public interface IMovieService
{
    Task<HttpResponseMessage> AuthenticateAsync();

    Task<MovieResponse> GetPopulars(int page);
    Task<NowPlaying> GetNowPlaying(int page);

    //  fetchNowPlaying: "movie/now_playing",
    //fetchTrending: "/trending/all/week",
    //fetchTopRated: "/movie/top_rated",
    //fetchActionMovies: "/discover/movie?with_genres=28",
    //fetchComedyMovies: "/discover/movie?with_genres=35",
    //fetchHorrorMovies: "/discover/movie?with_genres=27",
    //fetchRomanceMovies: "/discover/movie?with_genres=10749",
    //fetchDocumentaries: "/discover/movie?with_genres=199",
}