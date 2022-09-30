using AutoMapper;
using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Models.Insert;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerce.Project.Backend.Domain.Controller
{
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

        [HttpPost]
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


    }
}
