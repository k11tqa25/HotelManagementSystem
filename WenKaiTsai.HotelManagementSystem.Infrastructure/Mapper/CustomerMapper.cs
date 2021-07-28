using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.Models;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer ToEntity(CustomerRequestModel request)
        {
            return new Customer()
            {
                CNAME = request.Name,
                ADDRESS = request.Address,
                PHONE = request.PhoneNumber,
                BOOKINGDAYS = request.BookingDays,
                TOTALPERSONS = request.TotalPerson,
                ADVANCE = request.Advance,
                EMAIL = request.Email,
                CHECKIN = request.CheckInDate,
                ROOMNO = request.RoomNumber
            };
        }

        public Customer ToEntityWithId(int id, CustomerRequestModel request)
        {
            return new Customer()
            {
                Id = id,
                CNAME = request.Name,
                ADDRESS = request.Address,
                PHONE = request.PhoneNumber,
                BOOKINGDAYS = request.BookingDays,
                TOTALPERSONS = request.TotalPerson,
                ADVANCE = request.Advance,
                EMAIL = request.Email,
                CHECKIN = request.CheckInDate,
                ROOMNO = request.RoomNumber
            };
        }

        public CustomerResponseModel ToResponse(Customer entity)
        {
            return new CustomerResponseModel()
            {
                Id = entity.Id,
                Name = entity.CNAME,
                Address = entity.ADDRESS,
                PhoneNumber = entity.PHONE,
                RoomNumber = entity.ROOMNO.GetValueOrDefault(),
                TotalPerson = entity.TOTALPERSONS.GetValueOrDefault(),
                Email = entity.EMAIL,
                Advance = entity.ADVANCE.GetValueOrDefault(),
                BookingDays = entity.BOOKINGDAYS.GetValueOrDefault(),
                CheckInDate = entity.CHECKIN.GetValueOrDefault()
            };
        }
    }
}
