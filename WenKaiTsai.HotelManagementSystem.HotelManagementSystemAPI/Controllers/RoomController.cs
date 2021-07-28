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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AddRoom(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null) return NotFound("No room is found.");
            return Ok(room);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRoom([FromBody] RoomRequestModel model)
        {
            var room = await _roomService.AddAsync(model);
            if (room == null) return BadRequest();
            return Ok(room);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.DeleteByIdAsync(id);
            if (room == null) return NotFound("No room is found.");
            return Ok(room);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomRequestModel model)
        {
            var room = await _roomService.UpdateWithIdAsync(id, model);
            if (room == null) return NotFound("No room is found.");
            return Ok(room);
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> LIstAllRooms()
        {
            var rooms = await _roomService.ListAllAsync();
            if (rooms == null) return NotFound("No room is found.");
            return Ok(rooms);
        }

        [HttpGet]
        [Route("filter-by-room-type/{type_id:int}")]
        public async Task<IActionResult> GetRoomByTypeId(int type_id)
        {
            var room = await _roomService.FilterAsync<Room>(r => r.RoomType.Id == type_id);
            if (room == null) return NotFound("No room is found.");
            return Ok(room);
        }
    }
}
