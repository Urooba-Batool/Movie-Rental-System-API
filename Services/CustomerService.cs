using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class CustomerService : ICustomerService
    {
        
        private readonly MovieRentalSystemContext _context;

        public CustomerService(MovieRentalSystemContext context)
        {
            _context = context;
        }


        public List<Customers> GetCustomers()
        {
            return _context.Customers.ToList(); 
        }

        public Customers? GetCustomersById(int id)
        {
            return _context.Customers.Find(id);
        }
        public Customers? UpdateCustomers(int id, Customers updateCustomers)
        {
            var customers = _context.Customers.Find(id);
            if(customers == null)
            {
                return null;
            }
            customers.FirstName = updateCustomers.FirstName;
            customers.LastName = updateCustomers.LastName;
            customers.Email = updateCustomers.Email;
            customers.Age = updateCustomers.Age;
            customers.Address = updateCustomers.Address;
            _context.SaveChanges();
            return customers;
        }
        public Customers? PatchCustomers(int id, Customers updateCustomers)
        {
            var customers = _context.Customers.Find(id);
            if (customers == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(updateCustomers.FirstName))
            {
                customers.FirstName = updateCustomers.FirstName;
            }
            if (!string.IsNullOrEmpty(updateCustomers.LastName))
            {
                customers.LastName = updateCustomers.LastName;
            }
            if (!string.IsNullOrEmpty(updateCustomers.Email))
            {
                customers.Email = updateCustomers.Email;
            }
            if (updateCustomers.Age != 0)
            {
                customers.Age = updateCustomers.Age;
            }
            if (!string.IsNullOrEmpty(updateCustomers.Address))
            {
                customers.Address = updateCustomers.Address;
            }
            _context.SaveChanges();
            return customers;


        }
        public Customers AddCustomers(Customers addCustomers)
        {
            _context.Customers.Add(addCustomers);
            _context.SaveChanges();
            return addCustomers;
        }
    }
}
