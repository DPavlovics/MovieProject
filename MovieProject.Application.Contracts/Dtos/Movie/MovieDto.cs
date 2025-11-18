namespace MovieProject.Application.Contracts.Dtos.Movie
{
    public class MovieDto
    {
        public required string Title { get; init; } = string.Empty;
        public string? Year { get; init; } = string.Empty;
        public string? Rated { get; init; } = string.Empty;
        public string? Released { get; init; } = string.Empty;
        public string? Runtime { get; init; } = string.Empty;
        public string? Genre { get; init; } = string.Empty;
        public string? Director { get; init; } = string.Empty;
        public string? Writer { get; init; } = string.Empty;
        public string? Actors { get; init; } = string.Empty;
        public string? Plot { get; init; } = string.Empty;
        public string? Language { get; init; } = string.Empty;
        public string? Country { get; init; } = string.Empty;
        public string? Awards { get; init; } = string.Empty;
        public string? Poster { get; init; } = string.Empty;
        public string? Metascore { get; init; } = string.Empty;
        public string? ImdbRating { get; init; } = string.Empty;
        public string? ImdbVotes { get; init; } = string.Empty;
        public string? ImdbID { get; init; } = string.Empty;
        public string? Type { get; init; } = string.Empty;
        public string? DVD { get; init; } = string.Empty;
        public string? BoxOffice { get; init; } = string.Empty;
        public string? Production { get; init; } = string.Empty;
        public string? Website { get; init; } = string.Empty;
        public string? Response { get; init; } = string.Empty;
        public IEnumerable<RatingDto>? Ratings { get; set; } = [];
    }
}
