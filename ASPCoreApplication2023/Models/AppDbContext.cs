using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Models
{
    public class AppDbContext : DbContext

    {
        // :base(options) veut dire que le constructeur de la classe parente DbContext est appelé avec le paramètre options
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Membershiptype> Membershiptypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }

// la methode onModelCreating s'execute quand on crée la base de données pour la première fois

        protected override void OnModelCreating(ModelBuilder model)
        {
            // base est la classe parente de AppDbContext qui est DbContext 
            // on appelle la méthode OnModelCreating de la classe parente DbContext pour lui passer le paramètre model et on exécute le code de la classe parente
            base.OnModelCreating(model);
            // read json file
            string GenreJSon = System.IO.File.ReadAllText("Genres.Json");
            // deserialize json to object
            // deserialize (json) : convertir un objet json en objet c#
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>().HasData(c);
        }



        public DbSet<Movie> Movies { get; set; }


    }
}
