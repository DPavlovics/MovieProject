using MovieProject.Domain.Enums;
using MovieProject.Domain.IProviders;
using MovieProject.Domain.IRepositories;
using MovieProject.Domain.Models;
using MovieProject.Domain.Models.Movie;

namespace MovieProject.Providers.Omdb.Repositories
{
    public class MovieRepository(IOmdbApiProvider apiProvider) : IMovieRepository
    {
        public async Task<BaseApiResponse<MovieModel?>> GetMovies(string movieTitle)
        {
            var queryParams = new Dictionary<string, string?>();
            queryParams["t"] = movieTitle;

            return await apiProvider.ExecuteCall<MovieModel?>(HttpMethodType.Get, "", queryParams);
        }
    }
}
