using ASPCoreApplication2023.Models;

public interface IMovieService
{
    public List<Movie> GetMoviesByGenre(string genreName);

    public List<Movie> GetMoviesByGenreID(int genreId);

    public List<Movie> GetMoviesSortedByReleaseDate();

}