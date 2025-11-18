using MovieProject.Domain.Models.Movie;

namespace MovieProject.Domain.IRepositories
{
    public interface IQueryHistoryRepository
    {
        Task<IEnumerable<MovieModel>> GetAsync();
        Task SaveAsync(MovieModel movie);
    }
}
