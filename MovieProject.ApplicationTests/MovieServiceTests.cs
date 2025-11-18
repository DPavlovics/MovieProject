using Moq;
using MovieProject.Application.Services;
using MovieProject.Domain.IRepositories;
using MovieProject.Domain.Models;
using MovieProject.Domain.Models.Movie;
using System.Net;

namespace MovieProject.ApplicationTests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> movieRepositoryMock = new();
        private readonly Mock<IQueryHistoryRepository> historyRepositoryMock = new();

        private MovieService movieService => new(movieRepositoryMock.Object, historyRepositoryMock.Object);

        #region GetMovieByTitle

        [Fact]
        [Trait("GetMovieByTitle", "Should return async ServiceResponse with MovieDto")]
        public async Task GetMovieByTitle_ReturnsOk_WhenMovieFound()
        {
            var repResponse = new BaseApiResponse<MovieModel?>
            {
                ResponseCode = HttpStatusCode.OK,
                Result = new MovieModel { Title = "Inception" }
            };

            movieRepositoryMock.Setup(r => r.GetMovies("Inception")).ReturnsAsync(repResponse);

            var response = await movieService.GetMovieByTitle("Inception");

            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Data);
            Assert.Equal("Inception", response.Data.Title);

            historyRepositoryMock.Verify(h => h.SaveAsync(repResponse.Result), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("GetMovieByTitle", "Should return async ServiceResponse with error message and empty Data")]
        public async Task GetMovieByTitle_ReturnsBadRequest_WhenResultIsNull(bool statusCodeOk)
        {
            var response = new BaseApiResponse<MovieModel?>
            {
                ResponseCode = statusCodeOk ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                Result = statusCodeOk ? null : new MovieModel { Title = "Inception" },
                ErrorMessage = "Error description"
            };

            movieRepositoryMock.Setup(r => r.GetMovies("Empty")).ReturnsAsync(response);

            var result = await movieService.GetMovieByTitle("Empty");

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.ErrorMessage);
            Assert.Null(result.Data);
            historyRepositoryMock.Verify(q => q.SaveAsync(It.IsAny<MovieModel>()), Times.Never);
        }

        #endregion
    }
}
