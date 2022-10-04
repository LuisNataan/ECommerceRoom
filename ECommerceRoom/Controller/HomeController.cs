using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Project.Backend.Web.Controller
{
    public class HomeController : ControllerBase
    {
        private ISupplierService _supplierService;
        private ICustomerService _customerService;

        public HomeController(ISupplierService supplierService, ICustomerService customerService)
        {
            _supplierService = supplierService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Supplier> suppliers = await _supplierService.GetAll();
                List<Customer> customers = await _customerService.GetAll();

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
