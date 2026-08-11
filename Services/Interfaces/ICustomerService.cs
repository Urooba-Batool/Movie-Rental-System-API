using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customers> GetCustomers();
        Customers? GetCustomersById(int id);
        Customers? UpdateCustomers(int id, Customers updateCustomers);
        Customers? PatchCustomers(int id, Customers updateCustomers);
        Customers AddCustomers(Customers addCustomers);
    }
}
