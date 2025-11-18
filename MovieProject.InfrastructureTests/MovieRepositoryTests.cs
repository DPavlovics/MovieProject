using Moq;
using MovieProject.Domain.IProviders;
using MovieProject.Providers.Omdb.Repositories;

namespace MovieProject.InfrastructureTests
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IOmdbApiProvider> apiProviderMock;
        private readonly MovieRepository moviesRepository;

        public MovieRepositoryTests()
        {
            apiProviderMock = new Mock<IOmdbApiProvider>();
            moviesRepository = new MovieRepository(apiProviderMock.Object);
        }


        [Fact]
        public void Test1()
        {

        }
    }
}
