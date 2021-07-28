using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class ServiceResponseModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
