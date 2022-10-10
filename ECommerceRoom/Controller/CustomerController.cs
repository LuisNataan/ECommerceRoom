using AutoMapper;
using ECommerce.Project.Backend.Application.Commom;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Web.Models.Insert;
using ECommerce.Project.Backend.Web.Utils.Signal_Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Project.Backend.Web.Controller
{
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly IMapper _mapper;
        private readonly IHubContext<SignalHub> _hubContext;

        public CustomerController(ICustomerService customer, IMapper mapper, IHubContext<SignalHub> hubContext)
        {
            _customer = customer;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CustomerInsertViewModel customerInsertView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customer.Create(_mapper.Map<Customer>(customerInsertView));
                }
                await _hubContext.Clients.All.SendAsync("NotificationMessage", $"Customer successfully created. {customerInsertView.Name}");
                return Ok(customerInsertView);
            }
            catch (Exceptions ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CustomerInsertViewModel customerInsertView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customer.Update(_mapper.Map<Customer>(customerInsertView));
                }

                await _hubContext.Clients.All.SendAsync("NotificationMessage", $"Customer updated. {customerInsertView.Name}");
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

        [HttpGet("Customers")]
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await _customer.GetAll();
            }
            catch (Exception ex)
            {
                return null;
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
