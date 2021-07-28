using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AddService(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null) return NotFound("No service is found.");
            return Ok(service);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestModel model)
        {
            var service = await _serviceService.AddAsync(model);
            if (service == null) return BadRequest();
            return Ok(service);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceService.DeleteByIdAsync(id);
            if (service == null) return NotFound("No service is found.");
            return Ok(service);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceRequestModel model)
        {
            var service = await _serviceService.UpdateWithIdAsync(id, model);
            if (service == null) return NotFound("No service is found.");
            return Ok(service);
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> LIstAllServices()
        {
            var services = await _serviceService.ListAllAsync();
            if (services == null) return NotFound("No service is found.");
            return Ok(services);
        }

        [HttpGet]
        [Route("paid-services")]
        public async Task<IActionResult> GetPaidServices()
        {
            var services = await _serviceService.FilterAsync<Service>(s => s.AMOUNT != 0);
            if (services == null) return NotFound("No service is found.");
            return Ok(services);
        }

        [HttpGet]
        [Route("free-services")]
        public async Task<IActionResult> GetFreeServices()
        {
            var services = await _serviceService.FilterAsync<Service>(s => s.AMOUNT == 0);
            if (services == null) return NotFound("No service is found.");
            return Ok(services);
        }
    }
}
