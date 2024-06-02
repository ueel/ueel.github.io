using Yamine.Shared.TheMovie;

namespace Yamine.Pages.Movie;

public partial class NowPlaying
{

    bool allowVirtualization;
    public IEnumerable<MovieInfo> Movies { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var results = await movie.GetNowPlaying(1);

        Movies = results.results;
    }

}
