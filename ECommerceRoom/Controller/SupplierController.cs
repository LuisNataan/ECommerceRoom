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
            return Content("Welcome to the ECommerce!");
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

                return Ok();
            }
            catch (Exceptions ex)
            {
                return UnprocessableEntity(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPatch("{id}/" +
            "Update")]
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

                return Ok();
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



        [HttpDelete("Delete")]
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
