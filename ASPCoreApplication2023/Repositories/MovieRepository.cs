using ASPCoreApplication2023.Models;
using Microsoft.EntityFrameworkCore;


public class MovieRepository
{

    private readonly AppDbContext _appDbContext;

    public MovieRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Movie> GetAllMovies()
    {
        return _appDbContext.Movies.Include(c => c.Genre).ToList();
    }

    public Movie GetMovieById(int id)
    {
        return _appDbContext.Movies.FirstOrDefault(m => m.Id == id);
    }

    public void CreateMovie(Movie movie)
    {
        _appDbContext.Movies.Add(movie);
        _appDbContext.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();
    }

    public void DeleteMovie(Movie movie)
    {
        _appDbContext.Movies.Remove(movie);
        _appDbContext.SaveChanges();
    }

    public List<Movie> GetMoviesByGenreID(int genreId)
    {
        return _appDbContext.Movies.Where(m => m.GenreId == genreId).ToList();
    }

    // desc
    public List<Movie> GetMoviesSortedByReleaseDateDescending()
    {
        return _appDbContext.Movies.Include(c => c.Genre).OrderByDescending(m => m.ReleaseDate).ToList();
    }


    public List<Movie> GetMoviesByGenre(string genreName)
    {
        return _appDbContext.Movies.Include(c => c.Genre).Where(m => m.Genre.Name == genreName).ToList();
    }

}