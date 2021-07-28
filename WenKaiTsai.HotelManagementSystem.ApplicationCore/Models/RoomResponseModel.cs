using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public bool Status { get; set; }
    }
}
