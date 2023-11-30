namespace ASPCoreApplication2023.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int membershiptypeid { get; set; }
        public Membershiptype? membershiptype { get; set; }
        public List<Movie>? Movies { get; set; }



    }
}
