namespace Yamine.Shared.TheMovie.Movie;

public class PopularResponse
{
    public int page { get; set; }
    public List<MovieResponse> results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}
