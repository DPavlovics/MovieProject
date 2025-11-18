using Microsoft.AspNetCore.Components.Web;
using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Application.Contracts.IServices;

namespace MovieProject.Web.Components.Pages
{
    public partial class SearchMovie(IMovieService movieService)
    {
        private string searchTerm = string.Empty;
        private MovieDto? movie;
        private bool isLoading = false;
        private bool hasSearched = false;
        private string? errorMessage;

        protected async Task SearchMovieByTitle()
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return;

            isLoading = true;
            hasSearched = true;
            errorMessage = null;
            movie = null;

            var response = await movieService.GetMovieByTitle(searchTerm);

            if (!response.IsSuccessful)
            {
                errorMessage = response.ErrorMessage;
                isLoading = false;
                return;
            }

            movie = response.Data;
            isLoading = false;
        }

        protected async Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
                await SearchMovieByTitle();
        }
    }
}