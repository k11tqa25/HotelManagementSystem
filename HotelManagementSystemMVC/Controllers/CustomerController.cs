using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;

        public CustomerController(ICustomerService customerService, IRoomService roomService)
        {
            _customerService = customerService;
            _roomService = roomService;
        }

        public async Task<IActionResult> RemoveCustomer(int id)
        {
            var deletedCustomer = await _customerService.DeleteByIdAsync(id);
            if(deletedCustomer != null)
            {
                int roomId = deletedCustomer.RoomNumber;
                var room = await _roomService.GetByIdAsync(roomId);
                var updateRoomRequest = new RoomRequestModel()
                {
                    RoomTypeId = room.RoomTypeId,
                    Status = false
                };
                
                var update = await _roomService.UpdateWithIdAsync(roomId, updateRoomRequest);
            } 
            return RedirectToAction("Index","Home");
        }

    }
}
