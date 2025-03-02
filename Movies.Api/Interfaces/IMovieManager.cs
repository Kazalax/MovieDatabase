using Movies.Api.Models;

namespace Movies.Api.Interfaces
{
    public interface IMovieManager
    {
        MovieDto AddMovie(MovieDto movieDto);
        MovieDto? DeleteMovie(uint movieId);
        IList<MovieDto> GetAllMovies(MovieFilterDto? movieFilterDto = null);
        ExtendedMovieDto? GetMovie(uint movieId);
        MovieDto? UpdateMovie(uint movieId, MovieDto movieDto);
    }
}
