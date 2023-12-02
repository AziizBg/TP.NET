using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository, AppDbContext _appDbContext)
        {
            _customerRepository = customerRepository;
        }


        // GET: CustomerController/Details/
        //list all customers
        public ActionResult Details()
        {
            // List<Customer> list = _appDbContext.Customers.Include(c => c.membershiptype).ToList();
            List<Customer> list = _customerRepository.GetAllCustomers();
            return View(list);
        }

        // Post: CustomerController/Create
        public IActionResult Create()
        {
            var members = _appDbContext.Membershiptypes.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Value = members.Id.ToString(),
                Text = members.Name
            });
            //on a stocké les membres dans le viewbag. les membres sont des objets de la classe membershiptype
            //le viewbag se compose d'une liste de selectlistitem appelé member qui contient les membres 
            // chaque membre est un selectlistitem qui contient le nom et l'id du membre
            // text et value sont des noms de propriétés de selectlistitem. ce choix de nom est arbitraire
            // on veut afficher le nom du membre et on veut stocker l'id du membre

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            //example list of errors
            // List<string> errors = new List<string>();
            // errors.Add("error 1");
            // errors.Add("error 2");
            // ViewBag.errors = errors;

            ViewBag.errors = ModelState.Values
             .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }

            _customerRepository.CreateCustomer(c);
            // _appDbContext.Customers.Add(c);
            // _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Details));
        }


    }
}
