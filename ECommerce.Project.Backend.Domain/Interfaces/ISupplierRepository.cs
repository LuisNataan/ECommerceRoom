using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Domain.Interfaces
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<bool> SupplierAlreadyExists(string einNumber);
        Task<bool> SameEinNumberSupplier(string einNumber, int id);
        Task<Supplier> GetSupplier(string einNumber);
        Task<List<Supplier>> GetAll();
    }
}
