using System.ComponentModel.DataAnnotations;

namespace ASPCoreApplication2023.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string? Name { get; set; }
        public List<Movie>? Movies { get; set; }

    }
}
