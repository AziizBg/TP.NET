
using ASPCoreApplication2023.Models;

public class CustomerRepository
{

    private readonly AppDbContext _appDbContext;

    public CustomerRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Customer> GetAllCustomers()
    {
        return _appDbContext.Customers.ToList();
    }

    public Customer GetCustomerById(int id)
    {
        return _appDbContext.Customers.FirstOrDefault(m => m.Id == id);
    }

    public void CreateCustomer(Customer customer)
    {
        _appDbContext.Customers.Add(customer);
        _appDbContext.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        _appDbContext.Customers.Update(customer);
        _appDbContext.SaveChanges();
    }

    public void DeleteCustomer(Customer customer)
    {
        _appDbContext.Customers.Remove(customer);
        _appDbContext.SaveChanges();
    }


}