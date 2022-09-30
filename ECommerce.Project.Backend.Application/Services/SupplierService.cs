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
            await _supplierRepository.SaveChanges();
        }

        public async Task Update(Supplier supplier)
        {
            await _supplierRepository.Update(supplier);
            await _supplierRepository.SaveChanges();
        }

        public async Task Delete(Supplier supplier)
        {
            await _supplierRepository.Delete(supplier);
            await _supplierRepository.SaveChanges();
        }

        public async Task<List<Supplier>> GetAll()
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

        public async Task<bool> SupplierAlreadyExists(string einNumber)
        {
            try
            {
                return await _supplierRepository.SupplierAlreadyExists(einNumber);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
