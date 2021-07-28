using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AddCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound("No customer is found.");
            return Ok(customer);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.AddAsync(model);
            if (customer == null) return BadRequest();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteByIdAsync(id);
            if (customer == null) return NotFound("No customer is found.");
            return Ok(customer);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.UpdateWithIdAsync(id, model);
            if (customer == null) return NotFound("No customer is found.");
            return Ok(customer);
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> LIstAllCustomers()
        {
            var customers = await _customerService.ListAllAsync();
            if (customers == null) return NotFound("No customer is found.");
            return Ok(customers);
        }
    }
}
