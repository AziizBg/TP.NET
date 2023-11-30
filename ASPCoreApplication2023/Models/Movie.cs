using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreApplication2023.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? PictureURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Customer>? Customers { get; set; }

        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }

        [NotMapped]
        public IFormFile? PictureFile { get; set; }


        //ctor : constructor
        //prop: myProperty
        public Movie()
        {
        }
    }
}
