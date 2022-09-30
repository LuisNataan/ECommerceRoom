using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Domain.Validations;

namespace ECommerce.Project.Backend.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        
        public SupplierService(ISupplierRepository supplier)
        {
            this._supplierRepository = supplier;
        }

        public async Task Create(Supplier supplier)
        {
            var result = new SupplierValidation().Validate(supplier);
            result.ThrowExceptionIfFails();

            await _supplierRepository.Create(supplier);
        }

        public async Task Delete(Supplier supplier)
        {
            await _supplierRepository.Delete(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAll(Supplier supplier)
        {
            return await _supplierRepository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _supplierRepository.GetById(id);
        }

        public async Task<bool> SameEinNumberSupplier(string einNumber, int id)
        {
            try
            {
                return await _supplierRepository.SameEinNumberSupplier(einNumber, id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            
        }

        public Task<bool> SupplierAlreadyExists(string einNumber)
        {
            throw new NotImplementedException();
        }

        public Task Update(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
