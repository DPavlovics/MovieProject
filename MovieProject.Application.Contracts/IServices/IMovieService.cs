using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Application.Contracts.Models;

namespace MovieProject.Application.Contracts.IServices
{
    public interface IMovieService
    {
        Task<ServiceResponse<MovieDto>> GetMovieByTitle(string movieTitle);
    }
}
