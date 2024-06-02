namespace Yamine.Shared.TheMovie;

public class MovieResponse
{
    public int page { get; set; }
    public List<MovieInfo>? results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}


public class NowPlaying : MovieResponse
{
    public Dates? dates { get; set; }
}

public class Dates
{
    public DateTime maxium { get; set; }
    public DateTime minimum { get; set; }
}

public class MovieInfo
{
    public bool Adult { get; set; }
    public List<int>? Genre_Ids { get; set; }
    public int Id { get; set; }
    public string? Original_Language { get; set; }
    public string? Original_Title { get; set; }
    public string? Overview { get; set; }
    public double Popularity { get; set; }
    public string? Title { get; set; }
    public bool Video { get; set; }
    public double Vote_Average { get; set; }
    public int Vote_Count { get; set; }

    public string? backdrop_path { get; set; }
    public string ThumnailPath => backdrop_path == null ? "images/duck-1864493.png" : $"https://image.tmdb.org/t/p/original/{backdrop_path}";
    
    public string? poster_path { get; set; }
    public string PosterPath => $"https://image.tmdb.org/t/p/original/{poster_path}";

    public string? release_date { get; set; }
    //public DateTime ReleaseDate
    //{
    //    get
    //    {
    //        if (DateTime.TryParse(Release_Date, out DateTime ParsedDate))
    //        {
    //            return ParsedDate;
    //        }
    //        else { return default; }
    //    }
    //}
}