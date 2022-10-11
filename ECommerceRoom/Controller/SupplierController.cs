using AutoMapper;
using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Models.Insert;
using ECommerce.Project.Backend.Web.Utils.Signal_Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Project.Backend.Domain.Controller
{
    [Route("Supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplier;
        private readonly IMapper _mapper;
        private readonly IHubContext<SignalHub> _hubContext;

        public SupplierController(ISupplierService supplier, IMapper mapper, IHubContext<SignalHub> hubContext)
        {
            _supplier = supplier;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SupplierInsertViewModel supplierViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _supplier.Create(_mapper.Map<Supplier>(supplierViewModel));
                }

                await _hubContext.Clients.All.SendAsync("NotificationMessage", $"Supplier successfully created. {supplierViewModel.CorporateName}");
                return Ok(supplierViewModel);
            }
            catch (Exceptions ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SupplierInsertViewModel supplierViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _supplier.Update(_mapper.Map<Supplier>(supplierViewModel));
                }

                await _hubContext.Clients.All.SendAsync("NotificationMessage", $"Supplier updated. {supplierViewModel.CorporateName}");
                return Ok(supplierViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSuppliers")]
        public async Task<List<Supplier>> GetAll()
        {
            try
            {
                return await _supplier.GetAll();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _supplier.GetById(id);
                if (customer != null)
                {
                    await _hubContext.Clients.All.SendAsync("SendNotification");
                    return Ok(customer);
                }
                else
                {
                    await _hubContext.Clients.All.SendAsync("SendNotification");
                    return NoContent();
                }
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
                await _supplier.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
