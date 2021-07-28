using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace WenKaiTsai.HotelManagementSystem.HotelManagementSystemMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ICustomerService _customerService;

        public ReservationController(IRoomService roomService, ICustomerService  customerService)
        {
            _roomService = roomService;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> NewReservation()
        {
            var rooms = await _roomService.ListAllAsync();
            ViewData["Rooms"] = rooms;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(CustomerRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                var rooms = await _roomService.ListAllAsync();
                ViewData["Rooms"] = rooms;
                return View();
            } 

            var newReservation = await _customerService.AddAsync(requestModel);
            if(newReservation  == null)
            {
                var rooms = await _roomService.ListAllAsync();
                ViewData["Rooms"] = rooms;
                ModelState.AddModelError(string.Empty, "Unable to add a new reservation.");
                return View();
            }

            int roomId = newReservation.RoomNumber;
            var registeredRoom = await _roomService.GetByIdAsync(roomId);
            var updateRoomRequest = new RoomRequestModel()
            {
                RoomTypeId = registeredRoom.RoomTypeId,
                Status = true
            };
            var updatedRoom = await _roomService.UpdateWithIdAsync(registeredRoom.Id, updateRoomRequest);
            return RedirectToAction("Index", "Home");
        }
    }
}
