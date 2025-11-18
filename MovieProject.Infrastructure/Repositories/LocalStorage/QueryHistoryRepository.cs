using Blazored.LocalStorage;
using MovieProject.Domain.IRepositories;
using MovieProject.Domain.Models.Movie;

namespace MovieProject.Infrastructure.Repositories.LocalStorage
{
    public class QueryHistoryRepository(ILocalStorageService localStorageService) : IQueryHistoryRepository
    {
        const string queryHistory = "queryHistory";

        public async Task<IEnumerable<MovieModel>> GetAsync()
        {
            return await localStorageService.GetItemAsync<IEnumerable<MovieModel>>(queryHistory) ?? [];
        }

        public async Task SaveAsync(MovieModel movie)
        {
            var history = await localStorageService.GetItemAsync<List<MovieModel>>(queryHistory) ?? [];
            history.Insert(0, movie);

            if (history.Count > 5)
                history.RemoveRange(5, history.Count - 5);

            await localStorageService.SetItemAsync(queryHistory, history);
        }
    }
}
