using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> Authenticate(string email);
    }
}