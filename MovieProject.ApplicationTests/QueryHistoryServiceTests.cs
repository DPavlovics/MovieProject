using Moq;
using MovieProject.Application.Services;
using MovieProject.Domain.IRepositories;
using MovieProject.Domain.Models.Movie;
namespace MovieProject.ApplicationTests
{
    public class QueryHistoryServiceTests
    {
        private readonly Mock<IQueryHistoryRepository> queryHistoryRepositoryMock = new();

        private QueryHistoryService queryHistoryService => new(queryHistoryRepositoryMock.Object);

        #region GetQueryHistoryAsync

        [Fact]
        [Trait("GetQueryHistoryAsync", "Should return Enumerable when query history exists")]
        public async Task GetQueryHistoryAsync_ReturnsMappedMovieDtos_WhenHistoryExists()
        {
            var movieData = new List<MovieModel>
            {
                new() { Title = "Matrix", Year = "1999" },
                new() { Title = "Inception", Year = "2010" }
            };

            queryHistoryRepositoryMock.Setup(r => r.GetAsync()).ReturnsAsync(movieData);

            var result = await queryHistoryService.GetQueryHistoryAsync();

            var resultList = result.ToList();

            Assert.Equal(2, resultList.Count());
            Assert.Contains(resultList, x => x.Title == "Matrix");
            Assert.Contains(resultList, x => x.Title == "Inception");
        }

        [Fact]
        [Trait("GetQueryHistoryAsync", "Should return empty IEnumerable when query history is empty")]
        public async Task GetQueryHistoryAsync_ReturnsEmptyIEnumerable_WhenHistoryIsEmpty()
        {
            queryHistoryRepositoryMock.Setup(r => r.GetAsync()).ReturnsAsync([]);

            var result = await queryHistoryService.GetQueryHistoryAsync();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        #endregion
    }
}
