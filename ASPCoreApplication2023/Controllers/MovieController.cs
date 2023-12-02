using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
        // public readonly AppDbContext _appDbContext;
        public readonly IMovieService _movieService;
        public readonly GenreRepository _genreRepository;
        public readonly MovieRepository _movieRepository;
        

        public MovieController(IMovieService movieService, MovieRepository movieRepository, GenreRepository genreRepository)
        {
            // _appDbContext = appDbContext;
            _movieService = movieService;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }


        // index
        public IActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Details/
        //list all Movies
        public ActionResult Details()
        {
            // List<Movie> list = _appDbContext.Movies.Include(c => c.Genre).ToList();
            List<Movie> list = _movieRepository.GetAllMovies();
            return View(list);
        }

        // Post: MovierController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie c)
        {
            // on veut stocker les erreurs dans le viewbag
            // modelstate est un dictionnaire qui contient les erreurs de validation de chaque propriété du modèle (movie)
            // modelstate.values.selectmany(v => v.errors) retourne une liste d'erreurs, v étant une propriété du modèle 
            // modelstate.values.selectmany(v => v.errors).select(e => e.errormessage) retourne une liste de messages d'erreurs, e étant une erreur
            ViewBag.errors = ModelState.Values
             .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (c.PictureFile != null)
            {
                // file name
                var fileName = Path.GetFileName(c.PictureFile.FileName);
                // file path
                var filePath = Path.Combine("/Users/weszi/source/repos/ASPCoreApplication2023/ASPCoreApplication2023/wwwroot/", fileName);
                // using(){} est un bloc d'instructions qui permet de fermer le fichier après utilisation 
                // stream est un flux de données 
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // copie le fichier dans le stream pour le stocker dans le dossier wwwroot 
                    await c.PictureFile.CopyToAsync(stream);
                }
                c.PictureURL = "/" + fileName;
            }

            _movieRepository.CreateMovie(c);

            return RedirectToAction(nameof(Details));
        }

        [Route("movie/released/{month}/{year}")]
        public IActionResult ByRelease(int month, int year)
        {
            return Content("month = " + month + ", year= " + year);
        }

        // get movies by genre:
        [Route("movie/GenreMovies/{genreId}")]
        public IActionResult GenreMovies(int genreId)
        {
            List<Movie> movies = _movieService.GetMoviesByGenreID(genreId);

            // Genre genre = _appDbContext.Genres.Single(g => g.Id == genreId);
            Genre genre = _genreRepository.GetGenreById(genreId);

            MovieGenreViewModel viewModel = new MovieGenreViewModel(genre, movies);

            return View(viewModel);
        }

        // get movies sorted by release date:
        public IActionResult SortedByReleaseDate()
        {
            List<Movie> movies = _movieService.GetMoviesSortedByReleaseDateDescending();
            return View(movies);
        }

        // public IActionResult MovieDetails(int? id)
        // {
        //     if (id == null)
        //     {
        //         return View();
        //     }
        //     try
        //     {
        //         Movie movie = GetAllMovies().Single(c => c.Id == id);
        //         ViewModel viewModel = new ViewModel(movie, customers);
        //         return View(viewModel);
        //     }
        //     catch (Exception ex)
        //     {
        //         return View();
        //     }
        // }

        // public IActionResult CustomerDetails(int id)
        // {
        //     foreach (var customer in customers)
        //     {

        //         if (customer.Id != id)
        //         {
        //             continue;
        //         }
        //         return View(customer);

        //     }
        //     return View();
        // }
    }
}
