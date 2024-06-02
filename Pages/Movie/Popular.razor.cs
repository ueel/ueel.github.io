using Radzen;
using Yamine.Shared.TheMovie;

namespace Yamine.Pages.Movie;

public partial class Popular
{
    private int pageNumbersCount = 10;
    private int pageItemCount = 20;

    private int movieCount;

    public IEnumerable<MovieInfo> Movies { get; set; }
    public IList<MovieInfo> SelectedMovies { get; set; }

    private bool isLoading = false;

    async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;

        int page = args.Skip == 0 ? 1 : (int)(args.Skip / pageItemCount) + 1;
        var results = await movie.GetPopulars(page);
        Movies = results.results;

        isLoading = false;
    }


    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(100);
        movieCount = 1000;
    }



}
