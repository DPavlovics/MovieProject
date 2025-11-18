using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Application.Contracts.IServices;

namespace MovieProject.Web.Components.Pages
{
    public partial class QueryHistoryPage(IQueryHistoryService queryHistoryService)
    {
        private IEnumerable<MovieDto> recentSearches = [];
        private MovieDto? selectedMovie;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                recentSearches = await queryHistoryService.GetQueryHistoryAsync();
                StateHasChanged();
            }
        }
               
        private void ShowMovie(MovieDto movie)
        {
            selectedMovie = movie;
        }
    }
}