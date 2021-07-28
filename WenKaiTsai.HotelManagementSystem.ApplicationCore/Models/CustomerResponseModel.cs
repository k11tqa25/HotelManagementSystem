using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class CustomerResponseModel
    {        
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public int TotalPerson { get; set; }
        public int BookingDays { get; set; }
        public decimal Advance { get; set; }
    }
}
