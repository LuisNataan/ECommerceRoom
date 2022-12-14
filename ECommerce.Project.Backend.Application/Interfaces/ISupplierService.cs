using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Application.Interfaces
{
    public interface ISupplierService 
    {
        Task Create(Supplier supplier);
        Task Delete(int id);
        Task Update(Supplier supplier);
        Task<List<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<bool> SameEinNumberSupplier(string einNumber, int id);
        Task<bool> SupplierAlreadyExists(string einNumber);
    }
}
