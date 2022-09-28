using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Project.Backend.Infra.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MainContext context) : base(context)
        {
        }

        public async Task<Customer> Authenticate(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email && !c.Deleted);
        }

        public override async Task<Customer> GetById(int id)
        {
            return await _dbSet.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
        }
    }
}
