using AutoMapper;
using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Models.Insert;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Project.Backend.Domain.Controller
{
    [Route("Supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplier;

        public SupplierController(ISupplierService supplier)
        {
            _supplier = supplier;
        }


        public IActionResult Index()
        {
            return Content("Welcome to the ECommerce Room!");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(SupplierInsertViewModel supplierViewModel)
        {
            try
            {
                var config = new MapperConfiguration(s =>
                {
                    s.CreateMap<SupplierInsertViewModel, Supplier>();
                });
                IMapper mapper = config.CreateMapper();
                Supplier supplier = mapper.Map<Supplier>(supplierViewModel);
                await _supplier.Create(supplier);

                return Ok(supplier);
            }
            catch (Exceptions ex)
            {
                return UnprocessableEntity(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(SupplierInsertViewModel supplierInsertView)
        {
            try
            {
                var config = new MapperConfiguration(s => 
                {
                    s.CreateMap<SupplierInsertViewModel, Supplier>();
                });
                IMapper mapper = config.CreateMapper();
                Supplier supplier = mapper.Map<Supplier>(supplierInsertView);
                await _supplier.Create(supplier);

                return Ok(supplier);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                await _supplier.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> GetCustomerById(int id) 
        {
            try
            {
                var customer = await _supplier.GetById(id);
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


        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(SupplierInsertViewModel supplierInsertView)
        {
            try
            {
                var config = new MapperConfiguration(s => 
                {
                    s.CreateMap<SupplierInsertViewModel, Supplier>();
                });
                IMapper mapper = config.CreateMapper();
                Supplier supplier = mapper.Map<Supplier>(supplierInsertView);

                await _supplier.Delete(supplier);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
