namespace ASPCoreApplication2023.Models
{
    public class MovieGenreViewModel
    {
        public Genre Genre { get; set; }
        public List<Movie> Movies { get; set;}
        public MovieGenreViewModel(Genre genre, List<Movie> movies)
        {
            Movies = movies;
            Genre = genre;  
        }
    }
}
