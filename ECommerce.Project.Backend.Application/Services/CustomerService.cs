using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Domain.Validations;

namespace ECommerce.Project.Backend.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customer)
        {
            this._customerRepository = customer;
        }


        public async Task Create(Customer customer)
        {
            var result = new CustomerValidator().Validate(customer);
            result.ThrowExceptionIfFails();

            await _customerRepository.Create(customer);
            await _customerRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var customer = new Customer()
            {
                Id = id
            };
            await _customerRepository.Delete(customer);
            await _customerRepository.SaveChanges();
        }

        public async Task Update(Customer customer)
        {
            await _customerRepository.Update(customer);
            await _customerRepository.SaveChanges();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public Task<Customer> GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public async Task<Customer> Authenticate(string email)
        {
            return await _customerRepository.Authenticate(email);
        }
    }
}
