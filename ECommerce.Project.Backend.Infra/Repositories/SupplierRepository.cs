using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Project.Backend.Infra.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MainContext context) : base(context)
        {
        }

        public override async Task<Supplier> GetById(int id) 
        {
            return await _dbSet.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }

        public async Task<Supplier> GetSupplier(string einNumber)
        {
            return await Query().FirstOrDefaultAsync(s => s.EinNumber == einNumber);
        }

        public async Task<bool> SameEinNumberSupplier(string einNumber, int id)
        {
            return await Query().AnyAsync(s => s.EinNumber == einNumber && s.Id == id && !s.Deleted);
        }

        public async Task<bool> SupplierAlreadyExists(string einNumber)
        {
            return await Query().AnyAsync(s => s.EinNumber == einNumber && !s.Deleted);
        }
    }
}
