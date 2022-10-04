using AutoMapper;
using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Web.Models.Insert;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Project.Backend.Web.Controller
{
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customer, IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerInsertViewModel customerInsertView)
        {
            try
            {
                await _customer.Create(_mapper.Map<Customer>(customerInsertView));

                return Ok();
            }
            catch (Exceptions ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(CustomerInsertViewModel customerInsertView)
        {
            try
            {
                await _customer.Update(_mapper.Map<Customer>(customerInsertView));

                return Ok(customerInsertView);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customer.GetById(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                await _customer.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customer.Delete(id);
                return NoContent();
            }
            catch (Exceptions ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
