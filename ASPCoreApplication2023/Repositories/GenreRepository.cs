using ASPCoreApplication2023.Models;

public class GenreRepository
{
    private readonly AppDbContext _appDbContext;

    public GenreRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Genre> GetAllGenres()
    {
        return _appDbContext.Genres.ToList();
    }

    public Genre GetGenreById(int id)
    {
        return _appDbContext.Genres.FirstOrDefault(m => m.Id == id);
    }

    public void CreateGenre(Genre genre)
    {
        _appDbContext.Genres.Add(genre);
        _appDbContext.SaveChanges();
    }

    public void UpdateGenre(Genre genre)
    {
        _appDbContext.Genres.Update(genre);
        _appDbContext.SaveChanges();
    }

    public void DeleteGenre(Genre genre)
    {
        _appDbContext.Genres.Remove(genre);
        _appDbContext.SaveChanges();
    }


}