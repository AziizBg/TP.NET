using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreApplication2023.Controllers
{
    public class GenreController : Controller
    {
        // public readonly AppDbContext _dbContext;

        public readonly GenreRepository _genreRepository;

        public GenreController(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }


        // GET: GenreController
        public ActionResult Index()
        {
            // get all genres
            // List<Genre> genres = _dbContext.Genres.ToList();
            List<Genre> genres = _genreRepository.GetAllGenres();
            return View(genres);
        }


    }
}