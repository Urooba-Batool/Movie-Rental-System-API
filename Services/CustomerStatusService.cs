using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class CustomerStatusService : ICustomerStatusService
    {
        private readonly MovieRentalSystemContext _context;

        public CustomerStatusService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<CustomerStatus> GetCustomerStatus()
        {
            return _context.CustomerStatus.ToList();
        }

        public CustomerStatus? GetCustomerStatusById(int id)
        {
            return _context.CustomerStatus.Find(id);
        }

        public CustomerStatus AddCustomerStatus(CustomerStatus addCustomerStatus)
        {
            _context.CustomerStatus.Add(addCustomerStatus);
            _context.SaveChanges();
            return addCustomerStatus;
        }

        public CustomerStatus? UpdateCustomerStatus(int id, CustomerStatus updateCustomerStatus)
        {
            var customerStatus = _context.CustomerStatus.Find(id);
            if (customerStatus == null)
            {
                return null;
            }
            customerStatus.StatusName = updateCustomerStatus.StatusName;
            _context.SaveChanges();
            return customerStatus;

        }
        public CustomerStatus? PatchCustomerStatus(int id, CustomerStatus updateCustomerStatus)
        {
            var customerStatus = _context.CustomerStatus.Find(id);
            if (customerStatus == null)
            {
                return null;
            }
            customerStatus.StatusName = updateCustomerStatus.StatusName;
            _context.SaveChanges();
            return customerStatus;
        }
    }
}
