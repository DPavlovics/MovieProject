using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Application.Contracts.IServices;
using MovieProject.Application.Contracts.Mappers;
using MovieProject.Domain.IRepositories;

namespace MovieProject.Application.Services
{
    public class QueryHistoryService(IQueryHistoryRepository queryHistoryRepository) : IQueryHistoryService
    {
        public async Task<IEnumerable<MovieDto>> GetQueryHistoryAsync()
        {
            var data = await queryHistoryRepository.GetAsync();

            return data.Select(x => x.ToMovieDto());
        }
    }
}
