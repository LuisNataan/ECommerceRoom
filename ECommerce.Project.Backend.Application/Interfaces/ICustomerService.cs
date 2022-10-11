using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Application.Interfaces
{
    public interface ICustomerService
    {
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task<Customer> Authenticate(string email);
    }
}
