using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceContext _context;
        public CustomerRepository(EcommerceContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }

}
