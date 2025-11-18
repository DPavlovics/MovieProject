using Moq;
using MovieProject.Domain.Enums;
using MovieProject.Domain.IProviders;
using MovieProject.Domain.Models;
using MovieProject.Domain.Models.Movie;
using MovieProject.Providers.Omdb.Repositories;

namespace MovieProject.Omdb.IntegrationTests
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IOmdbApiProvider> apiProviderMock = new();
        private MovieRepository movieRepository => new(apiProviderMock.Object);

        #region GetMovies

        [Fact]
        [Trait("GetMovies", "Should return response with movie model result")]
        public async Task GetMovies_ReturnsReesponseWithResult()
        {
            string movieTitle = "Matrix";

            var expectedResponse = new BaseApiResponse<MovieModel?>
            {
                Result = new MovieModel { Title = "Matrix" }
            };

            apiProviderMock.Setup(p =>
                p.ExecuteCall<MovieModel?>(HttpMethodType.Get, "", It.IsAny<Dictionary<string, string?>>(), null)).ReturnsAsync(expectedResponse);

            var result = await movieRepository.GetMovies(movieTitle);

            Assert.Equal(expectedResponse, result);

            apiProviderMock.Verify(p =>
                p.ExecuteCall<MovieModel?>(HttpMethodType.Get, "", It.Is<Dictionary<string, string?>>(d =>
                    d.ContainsKey("t") && d["t"] == movieTitle), null), Times.Once);
        }

        [Fact]
        [Trait("GetMovies", "Should return empty result with error message")]
        public async Task GetMovies_ReturnsEmptyResponse_WhenApiReturnNull()
        {
            var expected = new BaseApiResponse<MovieModel?>
            {
                Result = null,
                ErrorMessage = "Not found"
            };

            apiProviderMock.Setup(p =>
                p.ExecuteCall<MovieModel?>(HttpMethodType.Get, "", It.IsAny<Dictionary<string, string?>>(), null)).ReturnsAsync(expected);

            var result = await movieRepository.GetMovies("Unknown");

            Assert.Equal(expected, result);
        }

        #endregion
    }
}
