using Radzen;
using Yamine.Shared.TheMovie.Movie;

namespace Yamine.Pages;

public partial class Movie
{
    private int pageNumbersCount = 10;
    private int pageItemCount = 20;

    private int movieCount;

    public IEnumerable<MovieResponse> Movies { get; set; }
    public IList<MovieResponse> SelectedMovies { get; set; }

    private bool isLoading = false;

    async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;

        int page = args.Skip == 0 ? 1 : (int)(args.Skip/ pageItemCount) + 1;

        var results = await movie.GetPopulars(page);

        Movies = results.results;

        isLoading = false;
    }


    protected override async Task OnInitializedAsync()
    {
        movieCount = 1000;
    }



}
