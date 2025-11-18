using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Application.Contracts.IServices;
using MovieProject.Application.Contracts.Mappers;
using MovieProject.Application.Contracts.Models;
using MovieProject.Application.Services.Base;
using MovieProject.Domain.IRepositories;

namespace MovieProject.Application.Services
{
    public class MovieService(IMovieRepository movieRepository, IQueryHistoryRepository queryHistoryRepository) : BaseService, IMovieService
    {
        public async Task<ServiceResponse<MovieDto>> GetMovieByTitle(string movieTitle)
        {
            var result = await movieRepository.GetMovies(movieTitle);

            if(result.ResponseCode != System.Net.HttpStatusCode.OK || result.Result == null)
                return BadRequest<MovieDto>(result.ErrorMessage ?? "An error occurred");            

            await queryHistoryRepository.SaveAsync(result.Result);
            return Ok(result.Result.ToMovieDto());
        }
    }
}
