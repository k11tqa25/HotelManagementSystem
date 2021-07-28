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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AddRoomType(int id)
        {
            var roomType = await _roomTypeService.GetByIdAsync(id);
            if (roomType == null) return NotFound("No room type is found.");
            return Ok(roomType);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequestModel model)
        {
            var roomType = await _roomTypeService.AddAsync(model);
            if (roomType == null) return BadRequest();
            return Ok(roomType);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await _roomTypeService.DeleteByIdAsync(id);
            if (roomType == null) return NotFound("No room type is found.");
            return Ok(roomType);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateRoomType(int id, [FromBody] RoomTypeRequestModel model)
        {
            var roomType = await _roomTypeService.UpdateWithIdAsync(id, model);
            if (roomType == null) return NotFound("No room type is found.");
            return Ok(roomType);
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> LIstAllRoomTypes()
        {
            var roomTypes = await _roomTypeService.ListAllAsync();
            if (roomTypes == null) return NotFound("No room type is found.");
            return Ok(roomTypes);
        }
    }
}
