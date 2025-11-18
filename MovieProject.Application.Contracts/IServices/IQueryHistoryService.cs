using MovieProject.Application.Contracts.Dtos.Movie;

namespace MovieProject.Application.Contracts.IServices
{
    public interface IQueryHistoryService
    {
        Task<IEnumerable<MovieDto>> GetQueryHistoryAsync();
    }
}
