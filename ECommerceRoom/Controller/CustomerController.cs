﻿using AutoMapper;
using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Web.Models.Insert;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Project.Backend.Web.Controller
{
    [Route("Cusotmer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;

        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        public IActionResult Index()
        {
            return Content("Welcome to to The ECommerce Room!");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerInsertViewModel customerInsertView)
        {
            try
            {
                var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<CustomerInsertViewModel, Customer>();
                });
                IMapper mapper = config.CreateMapper();
                Customer customer = mapper.Map<Customer>(customerInsertView);
                await _customer.Create(customer);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(CustomerInsertViewModel customerInsertView)
        {
            try
            {
                var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<CustomerInsertViewModel, Customer>();
                });
                IMapper mapper = config.CreateMapper();
                Customer customer = mapper.Map<Customer>(customerInsertView);

                await _customer.Update(customer);

                return Ok(customer);
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
    }
}