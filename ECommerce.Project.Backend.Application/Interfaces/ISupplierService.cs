using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Application.Interfaces
{
    public interface ISupplierService 
    {
        Task Create(Supplier supplier);
        Task Delete(Supplier supplier);
        Task Update(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<bool> SameEinNumberSupplier(string einNumber, int id);
        Task<bool> SupplierAlreadyExists(string einNumber);
    }
}
