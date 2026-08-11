using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface ICustomerStatusService
    {
        List<CustomerStatus> GetCustomerStatus();

        CustomerStatus? GetCustomerStatusById(int id);
        CustomerStatus AddCustomerStatus(CustomerStatus addCustomerStatus);
        CustomerStatus? UpdateCustomerStatus(int id, CustomerStatus updateCustomerStatus);
        CustomerStatus? PatchCustomerStatus(int id, CustomerStatus updateCustomerStatus);
    }
}
