namespace ASPCoreApplication2023.Models
{
    public class ViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set;}
        public ViewModel(Movie movie, List<Customer> customers)
        {
            Movie = movie;
            Customers = customers;  
        }
    }
}
