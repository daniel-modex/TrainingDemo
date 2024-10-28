using ECommerce.Models;

namespace ECommerce.Repository
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomers();
    }
}
