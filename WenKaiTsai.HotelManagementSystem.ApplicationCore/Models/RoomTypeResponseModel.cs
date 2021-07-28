using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class RoomTypeResponseModel
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public decimal Rent { get; set; }
    }
}
