using MovieProject.Application.Contracts.Dtos.Movie;
using MovieProject.Domain.Models.Movie;

namespace MovieProject.Application.Contracts.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToMovieDto(this MovieModel model) => new MovieDto
        {
            Title = model.Title,
            Year = model.Year,
            Rated = model.Rated,
            Released = model.Released,
            Runtime = model.Runtime,
            Genre = model.Genre,
            Director = model.Director,
            Writer = model.Writer,
            Actors = model.Actors,
            Plot = model.Plot,
            Language = model.Language,
            Country = model.Country,
            Awards = model.Awards,
            Poster = model.Poster,
            Ratings = model.Ratings?.Select(x => new RatingDto
                {
                    Source = x.Source,
                    Value = x.Value
                }),
            Metascore = model.Metascore,
            ImdbRating = model.ImdbRating,
            ImdbVotes = model.ImdbVotes,
            ImdbID = model.ImdbID,
            Type = model.Type,
            DVD = model.DVD,
            BoxOffice = model.BoxOffice,
            Production = model.Production,
            Website = model.Website,
            Response = model.Response
        };
    }
}
