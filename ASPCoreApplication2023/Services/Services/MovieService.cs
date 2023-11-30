using ASPCoreApplication2023.Models;
using Microsoft.EntityFrameworkCore;

public class MovieService : IMovieService
{

    private readonly AppDbContext _dbContext;

    public MovieService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Movie> GetMoviesByGenre(string genreName)
    {
        return _dbContext.Movies.Include(c => c.Genre).Where(m => m.Genre.Name == genreName).ToList();
    }

    public List<Movie> GetMoviesByGenreID(int genreId)
    {
        return _dbContext.Movies.Include(c => c.Genre).Where(m => m.GenreId == genreId).ToList();
    }

    public List<Movie> GetMoviesSortedByReleaseDate()
    {
        return _dbContext.Movies.Include(c => c.Genre).OrderByDescending(m => m.ReleaseDate).ToList();
    }



}