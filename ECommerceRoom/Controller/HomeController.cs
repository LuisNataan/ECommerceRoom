using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerce.Project.Backend.Web.Controller
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private ISupplierService _supplierService;
        private ICustomerService _customerService;

        public HomeController(ILogger<HomeController> logger, ISupplierService supplierService, ICustomerService customerService)
        {
            _logger = logger;
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

                return BadRequest(ex.Message);
            }
        }
    }
}
