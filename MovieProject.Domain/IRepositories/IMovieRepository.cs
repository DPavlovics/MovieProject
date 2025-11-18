using MovieProject.Domain.Models;
using MovieProject.Domain.Models.Movie;

namespace MovieProject.Domain.IRepositories
{
    public interface IMovieRepository
    {
        Task<BaseApiResponse<MovieModel?>> GetMovies(string movieTitle);
    }
}
